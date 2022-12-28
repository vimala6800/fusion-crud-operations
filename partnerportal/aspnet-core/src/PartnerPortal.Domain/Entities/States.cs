namespace PartnerPortal.Domain.Entities
{
    public class States
    {

        public Guid StateID { get; set; }
        public Guid CountryID { get; set; }
        public string StateName { get; set; }

        //Navigations
        public virtual ICollection<Country> Countries { get; set; }
        public virtual ICollection<Cities> Cities { get; set; }
    }
}
