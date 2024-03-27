using System.ComponentModel.DataAnnotations;

namespace apiDocuments.Validations
{
    public class MaxSizeFile: ValidationAttribute
    {
        private readonly int maxSizeMb;

        public MaxSizeFile(int MaxSizeMb)
        {
            maxSizeMb = MaxSizeMb;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }

            IFormFile formFile = value as IFormFile;

            if (formFile == null) 
            {
                return ValidationResult.Success;
            }

            if(formFile.Length > maxSizeMb * 1024 * 1024)
            {
                return new ValidationResult($"El peso del archivo no debe ser mayor a {maxSizeMb}Mb");
            }

            return ValidationResult.Success;
        }
    }
}
