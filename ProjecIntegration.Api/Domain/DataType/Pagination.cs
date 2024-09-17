using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DataType
{
    public class Pagination<T>
    {
        public List<T> Items { get; }
        public int PageIndex { get; }
        public int TotalPages { get; }
        public bool HasPreviousPage => PageIndex > 1;
        public bool HasNextPage => PageIndex < TotalPages;

        public Pagination(List<T> items, int pageIndex, int totalPages)
        {
            Items = items;
            PageIndex = pageIndex;
            TotalPages = totalPages;
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
            int count = source.Count();
            var TotalPagelist = (int)Math.Ceiling(count / (double)pageSize);

            List<T> items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            if (count > 0)
            {
                // si le nombre d'item est superieur a zero on renvoie une page paginer 
               
                return new Pagination<T>(items,pageNumber, TotalPagelist);
            }
            return new Pagination<T>(items, pageNumber, TotalPagelist); ;
        }
    }
}
