using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EQuiz.Models
{
    public class QuestionModel
    {
        public int q_id { get; set; }
        public int q_quiz { get; set; }
        public string q_question { get; set; }  
        public int q_status { get; set; }

    }
}