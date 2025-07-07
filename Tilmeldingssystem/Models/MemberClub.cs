namespace Tilmeldingssystem.Models
{
    public class MemberClub
    {
        public int MemberId { get; set; }
        public Member Member { get; set; }

        public int ClubId { get; set; }
        public Club Club { get; set; }
    }
}
