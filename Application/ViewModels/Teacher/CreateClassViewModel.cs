using Application.Helpers;
using Domain.Entities.ObjectEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.ViewModels.Teacher
{
    public class CreateClassViewModel
    {
        [Required]
        public string ClassName { get; set; }
        public List<Subject> Subjects { get; set; } 
        [ValidateEmailListAnnotation]
        public List<string> Invitations { get; set; }
    }
}
