using ChatbotSkeleton.Models;

namespace ChatbotSkeleton.Selectors
{
    public class ChatMessageTemplateSelector : DataTemplateSelector
    {
        public DataTemplate? UserTemplate { get; set; }
        public DataTemplate? BotTemplate { get; set; }

        protected override DataTemplate? OnSelectTemplate(object item, BindableObject container)
        {
            if (item is ChatMessage message)
            {
                return message.IsUser ? UserTemplate : BotTemplate;
            }
            return null;
        }
    }
}
