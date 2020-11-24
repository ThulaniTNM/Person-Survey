using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web_Application.Models {
    public class CustomValidationRadio : ValidationAttribute {
        protected override ValidationResult IsValid( object value, ValidationContext validationContext ) { 
            Person personInstance  = (Person)validationContext.ObjectInstance;
            Dictionary<string, string> likingInstance = personInstance.Liking.Options;
            foreach(var kvPair in likingInstance) {
                if (kvPair.Value =="" || kvPair.Value==null) {
                    return new ValidationResult(kvPair.Key +"Is required");
                }
            }
            return ValidationResult.Success;

        }

        }
    }