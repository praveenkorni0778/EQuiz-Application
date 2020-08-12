using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Quiz.Api.DataAccess;
using EQuiz.Models;
using System.Web.Http;

namespace EQuiz.Controllers
{
    public class QuizController : ApiController
    {
        List<QuizModel> quizList = new List<QuizModel>();
        QuizDataAccess quizDataAccess = new QuizDataAccess();
        // GET: Quiz

        public IEnumerable<QuizModel> Get()
        {
            DataTable dt;
            dt = quizDataAccess.Get();
            foreach (DataRow dr in dt.Rows)
            {
                QuizModel obj = new QuizModel();
                obj.q_id = (int)(dr["q_id"]);
                obj.q_name = (string)(dr["q_name"]);
                obj.q_instruction = (string)(dr["q_instruction"]);
                obj.q_duration = (TimeSpan)(dr["q_duration"]);
                obj.q_adder = (int)(dr["q_adder"]);
                obj.q_status = (int)(dr["q_status"]);
                obj.q_tag = (int)(dr.IsNull("q_tag") ? -1 : dr["q_tag"]);
                quizList.Add(obj);
            }
            return quizList;
        }
        public string Post([FromUri]QuizModel obj)
        {
            string result = quizDataAccess.Post(obj);
            return result;
        }
        
        [System.Web.Http.Route("api/Quiz/Update")]
        [System.Web.Http.HttpGet]
        [System.Web.Http.HttpPut]
        public string Put([FromUri]QuizModel obj)
        {            
            string result = quizDataAccess.Put(obj);
            return result;
        }

        [System.Web.Http.Route("api/Quiz/Delete")]
        [System.Web.Http.HttpGet]
        [System.Web.Http.HttpDelete]
        public string Delete(int id)
        {
            string result = quizDataAccess.Delete(id);
            return result;
        }


    }
}