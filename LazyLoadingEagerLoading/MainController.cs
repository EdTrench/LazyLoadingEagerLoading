using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LazyLoadingEagerLoading.Tests;

namespace LazyLoadingEagerLoading
{
    class MainController : ApplicationContext
    {
        private MainForm m_main;
        private Button m_startButton;

        public MainController()
        {
            m_main = new MainForm();
            BuildStartButton();
            m_main.Controls.Add(m_startButton);
            this.AttachUIEvents();
            m_main.Show();
        }

        private void BuildStartButton()
        {
            m_startButton = new Button();
            m_startButton.Name = "cmdStart";
            m_startButton.Text = "Start";
        }

        private void AttachUIEvents()
        {
            m_startButton.Click += new EventHandler(OnStartButtonClick);

        }

        private void OnStartButtonClick(object sender, EventArgs e)
        {
            Order_Fixture of = new Order_Fixture();
            of.Customer_and_OrderLines_are_not_loaded_when_loading_Order();
        }

    }
}
