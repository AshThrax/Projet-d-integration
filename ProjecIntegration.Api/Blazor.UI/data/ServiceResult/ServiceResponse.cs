
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ServiceResult
{
    /// <summary>
    /// géneric wrapper for web api 
    /// reponse
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ServiceResponse<T>
    {

       public T? Data { get; set; }
       public bool Success { get; set; }
       public string? Message { get; set; }
       public Errortype? Errortype { get; set; }
      
    }
}
