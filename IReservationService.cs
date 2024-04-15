namespace Ceng382_23_24_s_201812031
{
    public interface IReservationService
    {
        public void AddReservation(Reservation reservation, string reserverName);
        public void DeleteReservation(Reservation reservation);
        public void DisplayWeeklySchedule();
    }
}