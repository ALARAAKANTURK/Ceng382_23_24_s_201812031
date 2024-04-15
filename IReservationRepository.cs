namespace Ceng382_23_24_s_201812031
{
    public interface IReservationRepository
    {
        public void AddReservation(Reservation reservation);
        public void DeleteReservation(Reservation reservation);
        public List<Reservation> GetAllReservations();
    }
}