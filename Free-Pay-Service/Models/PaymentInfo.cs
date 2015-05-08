namespace FreePayService.Models
{
    public class PaymentInfo
    {
        public PaymentInfo() { }
        public PaymentInfo(int userId, int serviceId)
        {
            UserId = userId;
            ServiceId = serviceId;
        }
        public int PaymentInfoId { get; set; }
        public int UserId { get; set; }
        public int ServiceId { get; set; }
    }
}