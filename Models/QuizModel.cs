using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EQuiz.Models
{
    public class QuizModel
    {
        public int q_id { get; set; }
        public string q_name { get; set; }
        public string q_instruction { get; set; }
        public  TimeSpan q_duration { get; set; }
        public int q_status { get; set; }
        public int q_tag { get; set; }
        public int q_adder { get; set; }
    }
}