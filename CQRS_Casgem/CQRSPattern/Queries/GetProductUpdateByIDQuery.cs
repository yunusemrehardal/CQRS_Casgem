namespace CQRS_Casgem.CQRSPattern.Queries
{
    public class GetProductUpdateByIDQuery
    {
        public GetProductUpdateByIDQuery(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
