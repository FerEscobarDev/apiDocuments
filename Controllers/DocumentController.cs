﻿using apiDocuments.DTOs;
using apiDocuments.Models;
using apiDocuments.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace apiDocuments.Controllers
{
    [ApiController]
    [Route("api/v1/document")]
    public class DocumentController: ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        private readonly IFileStorage fileStorage;
        private readonly string container = "documentsfiles";

        public DocumentController(ApplicationDbContext context, IMapper mapper, IFileStorage fileStorage)
        {
            this.context = context;
            this.mapper = mapper;
            this.fileStorage = fileStorage;
        }

        [HttpGet(Name = "getDocuments")]
        public async Task<ActionResult<List<DocumentDTO>>> Get()
        {
            var documents = await context.Documents.ToListAsync();
            var dtoDocuments = mapper.Map<List<DocumentDTO>>(documents);
            return dtoDocuments;
        }

        [HttpGet("{id:int}", Name = "getDocument")]
        public async Task<ActionResult<DocumentDTO>> Get(int id)
        {
            var document = await context.Documents.FirstOrDefaultAsync(documentDb => documentDb.Id == id);

            if(document == null) { return NotFound(); }

            var dtoDocument = mapper.Map<DocumentDTO>(document);

            return dtoDocument;
        }

        [HttpPost(Name = "storeDocument")]
        public async Task<ActionResult> Post([FromForm] DocumentCreateDTO documentCreateDTO)
        {
            //var documentExist = await context.Documents.AnyAsync(documentDb => documentDb.CustomName == document.CustomName);

            //if(documentExist) 
            //{  
            //    return BadRequest($"Ya existe un documento con el nombre personalizado {document.CustomName}"); 
            //}
            
            var document = mapper.Map<Document>(documentCreateDTO);

            if(documentCreateDTO.DocumentFile != null) 
            {
                using (var memoryStream = new MemoryStream())//Extraer arreglo de bite de IformFile
                {
                    await documentCreateDTO.DocumentFile.CopyToAsync(memoryStream);
                    var data = memoryStream.ToArray();
                    var extension = Path.GetExtension(documentCreateDTO.DocumentFile.FileName);
                    document.DocumentFile = await fileStorage.SaveFile(data, extension, container, documentCreateDTO.DocumentFile.ContentType);
                }
            }

            context.Add(document);
            await context.SaveChangesAsync();

            var dtoDocument = mapper.Map<DocumentDTO>(document);

            return new CreatedAtRouteResult("getDocument", new { id = dtoDocument.Id }, dtoDocument);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromForm] DocumentCreateDTO documentCreateDTO)
        {
            var document =  await context.Documents.FirstOrDefaultAsync(documentDb => documentDb.Id == id);
            if (document == null) { return NotFound(); }

            document = mapper.Map(documentCreateDTO, document);

            if (documentCreateDTO.DocumentFile != null)
            {
                using (var memoryStream = new MemoryStream())//Extraer arreglo de bite de IformFile
                {
                    await documentCreateDTO.DocumentFile.CopyToAsync(memoryStream);
                    var data = memoryStream.ToArray();
                    var extension = Path.GetExtension(documentCreateDTO.DocumentFile.FileName);
                    document.DocumentFile = await fileStorage.EditFile(data, extension, container, document.DocumentFile, documentCreateDTO.DocumentFile.ContentType);
                }
            }

            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var documentExist = await context.Documents.AnyAsync(documentDb => documentDb.Id == id);
            if (!documentExist)
            {
                return NotFound();
            }

            context.Remove(new  Document { Id = id });
            await context.SaveChangesAsync();

            return NoContent();
        }
    }
}