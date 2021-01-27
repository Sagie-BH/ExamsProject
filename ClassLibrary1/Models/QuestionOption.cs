using Domain.Common;
using Domain.Entities.ObjectEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class QuestionOption : AppObject
    {
        public bool IsRightAnswer { get; set; }
        public string Text { get; set; }
        public QuestionObject Question { get; set; }

    }
}
