using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Quiz.Api.DataAccess;
using System.Web.Http;
using EQuiz.Models;

namespace EQuiz.Controllers
{
    public class QuestionController : ApiController
    {
        List<QuestionModel> quizList = new List<QuestionModel>();
        QuestionDataAccess questionDataAccess = new QuestionDataAccess();
        // GET: Quiz

        public IEnumerable<QuestionModel> Get(int id)
        {
            DataTable dt;
            dt = questionDataAccess.Get(id);
            foreach (DataRow dr in dt.Rows)
            {
                QuestionModel obj = new QuestionModel(); ;
                obj.q_id = (int)(dr["q_id"]);
                obj.q_quiz = (int)(dr["q_quiz"]);
                obj.q_question = (string)(dr["q_question"]);
                obj.q_status = (int)(dr["q_status"]);                
                quizList.Add(obj);
            }
            return quizList;
        }

        public string Post([FromUri]QuestionModel obj)
        {
           string result = questionDataAccess.Post(obj);
            return result;
        }

        public string Put([FromUri]QuestionModel obj)
        {
            string result = questionDataAccess.Post(obj);
            return result;
        }

        public string Delete(int id)
        {
            string result = questionDataAccess.Delete(id);
            return result;
        }
    }
}