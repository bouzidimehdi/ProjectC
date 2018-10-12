namespace WebApplication1.Paginator
{
    //a page-datastructure used to limit the amount of data
    //to return to the client. This data-structure comes to help
    //selecting large amount of entities from the database
    public class Page<T>
    {

        // index of the current selected page
        public int Index { get; set; }

        // amount of entities per page
        public T[] Items { get; set; }

        // Total pages
        public int TotalPages { get; set; }
    }
}