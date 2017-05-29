using Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GabrielKubisLoboCerto.Models
{

    public class CategoryListAPIModel : APIModel
    {
        //{Messagem: "OK", Result: {[],[]}}
        public IQueryable<Category> Result { get; set; }
    }


    public class CategoryAPIModel : APIModel
    {
        //{Message: "OK", Result: {}}
        public Category Result { get; set; }
    }
}