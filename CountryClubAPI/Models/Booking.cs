namespace CountryClubAPI.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public Member? Member { get; set; }
        public int MemberId { get; set; }
        public Facility? Facility { get; set; }
        public int FacilityId { get; set; }
        public DateTime StartTime { get; set; }
        public int Slots { get; set; }
    }
}
