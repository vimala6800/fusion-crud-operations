namespace PartnerPortal.Domain.Entities
{
    public class Cities
    {

        public Guid CityID { get; set; }
        public Guid StateID { get; set; }
        public string CityName { get; set; }

        //Navigations
        public virtual States State { get; set; }
    }
}
