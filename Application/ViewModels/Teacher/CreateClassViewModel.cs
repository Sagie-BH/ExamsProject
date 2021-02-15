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
        public long TeacherId { get; set; }
        public string TeacherName { get; set; }
        [Required]
        public string ClassName { get; set; }
        public Subject Subject { get; set; } 
        //[ValidateEmailListAnnotation]
        public List<string> Invitations { get; set; }
    }
}
