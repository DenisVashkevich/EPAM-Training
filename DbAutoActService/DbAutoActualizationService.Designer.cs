using System.IO;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System;

namespace DbAutoActService
{
    partial class DbAutoActualizationService
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.FileSystemWatcher = new System.IO.FileSystemWatcher();
            ((System.ComponentModel.ISupportInitialize)(this.FileSystemWatcher)).BeginInit();
            // 
            // FileSystemWatcher
            // 
            this.FileSystemWatcher.EnableRaisingEvents = true;
            this.FileSystemWatcher.Filter = "*.csv";
            this.FileSystemWatcher.IncludeSubdirectories = true;
            this.FileSystemWatcher.NotifyFilter = ((System.IO.NotifyFilters)((System.IO.NotifyFilters.FileName | System.IO.NotifyFilters.DirectoryName)));
            // 
            // DbAutoActualizationService
            // 
            this.ServiceName = "DbAutoActualizationService";
            ((System.ComponentModel.ISupportInitialize)(this.FileSystemWatcher)).EndInit();

        }

        #endregion

        private System.IO.FileSystemWatcher FileSystemWatcher;

    }
}
