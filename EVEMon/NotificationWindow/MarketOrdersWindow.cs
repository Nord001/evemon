﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using EVEMon.Common;
using EVEMon.Common.Controls;
using EVEMon.Common.SettingsObjects;

namespace EVEMon.NotificationWindow
{
    public partial class MarketOrdersWindow : EVEMonForm
    {
        private readonly bool m_init;

        public MarketOrdersWindow()
        {
            InitializeComponent();
            RememberPositionKey = "MarketOrdersWindow";
            m_init = true;
        }

        /// <summary>
        /// Gets or sets the grouping mode.
        /// </summary>
        [Browsable(false)]
        public Enum Grouping
        {
            get { return ordersList.Grouping; }
            set
            {
                ordersList.Grouping = value;

                if (!m_init)
                    return;

                ordersList.UpdateColumns();
                ordersList.Visibility = !ordersList.Orders.IsEmpty();
            }
        }

        /// <summary>
        /// Gets or sets the ShowIssuedFor mode.
        /// </summary>
        [Browsable(false)]
        public IssuedFor ShowIssuedFor
        {
            get { return ordersList.ShowIssuedFor; }
            set
            {
                ordersList.ShowIssuedFor = value;

                if (!m_init)
                    return;

                ordersList.UpdateColumns();
                ordersList.Visible = !ordersList.Orders.IsEmpty();
            }
        }

        /// <summary>
        /// Gets or sets the enumeration of orders to display.
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public IEnumerable<MarketOrder> Orders
        {
            get { return ordersList.Orders; }
            set { ordersList.Orders = value; }
        }

        /// <summary>
        /// Gets or sets the enumeration of displayed columns.
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public IEnumerable<IColumnSettings> Columns
        {
            get { return ordersList.Columns; }
            set
            {
                ordersList.Columns = value;

                if (!m_init)
                    return;

                ordersList.UpdateColumns();
                ordersList.Visibility = !ordersList.Orders.IsEmpty();
            }
        }
    }
}