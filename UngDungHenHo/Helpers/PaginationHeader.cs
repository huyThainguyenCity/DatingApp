namespace UngDungHenHo.Helpers
{
    public class PaginationHeader(int currentPage, int itemsPerpage, int totalItems, int totalPages)
    {   
        public int CurrentPage { get; set; } = currentPage;

        public int ItemsPerPage { get; set; } = itemsPerpage;

        public int TotalItems { get; set; } = totalItems;

        public int TotalPages { get; set; } = totalPages;
    }
}
