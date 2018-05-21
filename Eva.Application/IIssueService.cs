namespace Eva.Application
{
    public interface IIssueService
    {
        void checkin(int bookId, string memberId);
        void checkOut(int bookId, string memberId);

    }
}