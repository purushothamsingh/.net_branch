namespace MvcGroceryMangement.Models
{
    public class ApplyPagination
    {
        public int TotalItem { get; set; }
        public int CurrentPage { get;private set; }
        public int PageSize { get; private set; }
        
        public int TotalPages { get; private set; } 
        public int StartPage { get; private set; }

        public int EndPage { get; private set; }



        public ApplyPagination() { }

        public ApplyPagination(int totalItems, int page, int pageSize = 3) {

         int    totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);
            int currentPage = page;

            int startPage = currentPage - 3;
            int endPage = currentPage + 3;


            if (startPage <= 0)
            {
                endPage = endPage - (startPage - 1);
                startPage = 1;
            }

            if (endPage > totalPages)
            {
                endPage = totalPages;
                if (endPage > 3)
                {
                    startPage = endPage - 2;
                }
            }



            TotalPages = totalItems;
            CurrentPage = currentPage;
            PageSize = pageSize;
            TotalPages = totalPages;
            StartPage = startPage;
            EndPage = endPage;

        }

    }
}
