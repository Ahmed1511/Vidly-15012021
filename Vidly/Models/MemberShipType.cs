namespace Vidly.Models
{
    public class MemberShipType
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int DurationinMonths { get; set; }
        public int Fee { get; set; }
        public int DiscountRate { get; set; }


        public const int UnKnown = 0;
        public const int PayasYouGo = 1;
    }
}