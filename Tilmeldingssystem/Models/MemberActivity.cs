namespace Tilmeldingssystem.Models
{
    public class MemberActivity
    {
        public int MemberId { get; set; }
        public Member Member { get; set; }

        public int ActivityId { get; set; }
        public Activity Activity { get; set; }
    }
}
