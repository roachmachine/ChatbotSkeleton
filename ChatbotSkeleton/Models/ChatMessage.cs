namespace ChatbotSkeleton.Models
{
    public class ChatMessage
    {
        public string Text { get; set; } = string.Empty;
        public bool IsUser { get; set; }
        public DateTime Timestamp { get; set; }

        public ChatMessage()
        {
            Timestamp = DateTime.Now;
        }

        public ChatMessage(string text, bool isUser)
        {
            Text = text;
            IsUser = isUser;
            Timestamp = DateTime.Now;
        }
    }
}
