using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DataType
{
    public class Pagination<T>:List<T>
    {
        public int CurrentPage { get; private set; }
        public int TotalPages { get; private set; }
        public int PageSize { get; private set; }
        public int TotalCount { get; private set; }
        public bool HasPrevious => CurrentPage > 1;
        public bool HasNext => CurrentPage < TotalPages;
        public Pagination(List<T> items, int count, int pageNumber, int pageSize)
        {
            TotalCount = count;
            PageSize = pageSize;
            CurrentPage = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            AddRange(items);
        }
        public static Pagination<T> ToPagedList(List<T> Query, int pageNumber, int pageSize)
        {   
            var source= Query.AsQueryable(); // pource simplifier la vie 
            if(pageNumber < 1)
            {
                // si le numéro de la page est plus petit que 1 
                //on force le processuss
                pageNumber = 1;
            }
            if(pageSize < 1)
            {
                // si le nombre d'item est plus petit que 1 
                //on force le processuss a renvoyer au moins 1 element 
                pageSize = 1;
            }
            
            var count = source.Count();
            var items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            if (count > 0)
            {
                // si le nombre d'item est superieur a zero on renvoie une page paginer 
               
                return new Pagination<T>(items, count, pageNumber, pageSize);
            }
            return new Pagination<T>(items, count, pageNumber, pageSize); ;
        }
    }
}
