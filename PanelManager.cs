
namespace facebook_clone
{
    public class PanelManager
    {
        private readonly List<Panel> _panels;
        private Panel _defaultPanel;

        public PanelManager(Panel defaultPanel, params Panel[] panels)
        {
            _defaultPanel = defaultPanel;
            _panels = new List<Panel>(panels);
            ShowDefault();
        }

        public void ShowPanel(Panel panelToShow)
        {
            foreach (var panel in _panels)
            {
                panel.Visible = panel == panelToShow;
            }
        }

        public void ShowDefault()
        {
            ShowPanel(_defaultPanel);
        }
    }
}