using System.Collections.ObjectModel;
using ChatbotSkeleton.Models;

namespace ChatbotSkeleton
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<ChatMessage> Messages { get; set; }
        public ObservableCollection<string> ChatHistory { get; set; }

        private bool _sidebarExpanded = true;
        private bool _isCurrentChatSaved = false;

        public MainPage()
        {
            InitializeComponent();

            Messages = new ObservableCollection<ChatMessage>();
            ChatHistory = new ObservableCollection<string>();

            BindingContext = this;

            // Hook up Enter key handling for Windows
            MessageEditor.HandlerChanged += OnMessageEditorHandlerChanged;
        }

        private void OnMessageEditorHandlerChanged(object? sender, EventArgs e)
        {
#if WINDOWS
            if (MessageEditor.Handler?.PlatformView is Microsoft.UI.Xaml.Controls.TextBox textBox)
            {
                textBox.KeyDown += (s, args) =>
                {
                    if (args.Key == Windows.System.VirtualKey.Enter)
                    {
                        var shiftState = Microsoft.UI.Input.InputKeyboardSource.GetKeyStateForCurrentThread(Windows.System.VirtualKey.Shift);
                        bool isShiftPressed = shiftState.HasFlag(Windows.UI.Core.CoreVirtualKeyStates.Down);

                        if (!isShiftPressed)
                        {
                            args.Handled = true;
                            Dispatcher.Dispatch(() => OnSendClicked(this, EventArgs.Empty));
                        }
                    }
                };
            }
#endif
        }

        private void OnToggleSidebar(object? sender, EventArgs e)
        {
            _sidebarExpanded = !_sidebarExpanded;

            if (_sidebarExpanded)
            {
                SidebarColumn.Width = new GridLength(240);
                ToggleButton.Text = "☰";
                NewChatLabel.IsVisible = true;

                // Show history labels
                foreach (var child in HistoryList.ItemsSource as IEnumerable<string> ?? Enumerable.Empty<string>())
                {
                    // Labels visibility is handled in XAML binding - we just need to ensure the template reflects it
                }
            }
            else
            {
                SidebarColumn.Width = new GridLength(60);
                ToggleButton.Text = "→";
                NewChatLabel.IsVisible = false;

                // Hide history labels (icons only)
                // Labels visibility is handled in binding context
            }
        }

        private void OnNewChat(object? sender, EventArgs e)
        {
            Messages.Clear();
            _isCurrentChatSaved = false;
        }

        private void OnHistorySelected(object? sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.Count > 0)
            {
                var selectedHistory = e.CurrentSelection[0] as string;

                // For now, just start a new chat with a system message showing the selected history
                Messages.Clear();
                Messages.Add(new ChatMessage($"Loaded: {selectedHistory}", false));

                _isCurrentChatSaved = true;

                // Clear selection
                HistoryList.SelectedItem = null;
            }
        }

        private async void OnSendClicked(object? sender, EventArgs e)
        {
            var messageText = MessageEditor.Text?.Trim();

            if (string.IsNullOrWhiteSpace(messageText))
                return;

            // Add user message
            var userMessage = new ChatMessage(messageText, true);
            Messages.Add(userMessage);

            // Save to history if this is the first message
            if (!_isCurrentChatSaved && ChatHistory.Count < 50)
            {
                var historyTitle = messageText.Length > 30 
                    ? messageText.Substring(0, 30) + "..." 
                    : messageText;
                ChatHistory.Insert(0, historyTitle);
                _isCurrentChatSaved = true;
            }

            // Clear input
            MessageEditor.Text = string.Empty;

            // Auto-scroll to the last message
            await Task.Delay(100); // Small delay to ensure layout is updated
            if (Messages.Count > 0)
            {
                ChatCollectionView.ScrollTo(Messages[Messages.Count - 1], position: ScrollToPosition.End, animate: true);
            }

            // Simulate bot response
            await Task.Delay(500);
            var botMessage = new ChatMessage($"Echo: {messageText}", false);
            Messages.Add(botMessage);

            // Auto-scroll to bot message
            await Task.Delay(100);
            if (Messages.Count > 0)
            {
                ChatCollectionView.ScrollTo(Messages[Messages.Count - 1], position: ScrollToPosition.End, animate: true);
            }
        }
    }
}
