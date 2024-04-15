namespace Ceng382_23_24_s_201812031
{
    public class ReservationRepository : IReservationRepository
    {
        private FileHandler _fileHandler;
        private List<Reservation> _reservations;
        public ReservationRepository(FileHandler fileHandler)
        {
            _fileHandler = fileHandler;
            _reservations = _fileHandler.ReadFile<List<Reservation>>("ReservationData.json")?? [];
        }

        public void AddReservation(Reservation reservation)
        {
            if (_reservations.Any(x => x.Date == reservation.Date && x.Time == reservation.Time))
                return;
            _reservations.Add(reservation);
            _fileHandler.WriteFile("ReservationData.json",_reservations);
        }

        public void DeleteReservation(Reservation reservation)
        {
            if (!_reservations.Any(x => x.Date == reservation.Date && x.Time == reservation.Time))
                return;
            _reservations.Remove(reservation);
            _fileHandler.WriteFile("ReservationData.json", _reservations);
        }

        public List<Reservation> GetAllReservations()
        {
            return _reservations;
        }
    }
}
