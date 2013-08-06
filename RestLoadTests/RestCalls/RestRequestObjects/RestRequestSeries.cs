namespace RestCalls.RestRequestObjects
{
    public class RestRequestSeries
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int ProgramId { get; set; }
        public int SeriesTypeId { get; set; }
        public int CategoryId { get; set; }
        public int Count { get; set; }
        public int Duration { get; set; }
        public int[,] SessionTypeIds { get; set; }
        public double OnlinePrice { get; set; }
        public bool EnableTax1 { get; set; }
        public bool EnableTax2 { get; set; }
    }
}
