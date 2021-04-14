using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using GameOverlay.Drawing;
using GameOverlay.Windows;

namespace MakoCelo.Overlay
{
	public class Coh2Overlay : IDisposable
	{
		private StickyWindow _window;

		private readonly Dictionary<string, SolidBrush> _brushes;
		private readonly Dictionary<string, Font> _fonts;
		private readonly Dictionary<string, Image> _images;
		private string[] _plrNames;
		private string[] _plrRanks;


		public Coh2Overlay()
		{
			_brushes = new Dictionary<string, SolidBrush>();
			_fonts = new Dictionary<string, Font>();
			_images = new Dictionary<string, Image>();
		}

		private void _window_SetupGraphics(object sender, SetupGraphicsEventArgs e)
		{
			var gfx = e.Graphics;

			if (e.RecreateResources)
			{
				foreach (var pair in _brushes) pair.Value.Dispose();
				foreach (var pair in _images) pair.Value.Dispose();
			}

			_brushes["black"] = gfx.CreateSolidBrush(0, 0, 0, 0.8F); 
			_brushes["green"] = gfx.CreateSolidBrush(0, 255, 0, 0.8F);
			_brushes["background"] = gfx.CreateSolidBrush(0x33, 0x36, 0x3F,0);

			if (e.RecreateResources) return;

			_fonts["consolas"] = gfx.CreateFont("Consolas", 14);

		}

		private void _window_DestroyGraphics(object sender, DestroyGraphicsEventArgs e)
		{
			foreach (var pair in _brushes) pair.Value.Dispose();
			foreach (var pair in _fonts) pair.Value.Dispose();
			foreach (var pair in _images) pair.Value.Dispose();
		}

		private void _window_DrawGraphics(object sender, DrawGraphicsEventArgs e)
		{
			var gfx = e.Graphics;

			gfx.ClearScene(_brushes["background"]);

			gfx.FillRoundedRectangle(_brushes["black"], 0, 0, 500, 100, 8.0f);

			for (int i = 1; i < _plrNames.Length; i +=2)
            {
                if (_plrNames[i] != "")
                {
					gfx.DrawText(_fonts["consolas"], _brushes["green"], 10, i * 10, _plrNames[i] + " " + _plrRanks[i]);
				}
            }

			for (int i = 2; i < _plrNames.Length; i += 2)
			{
				if (_plrNames[i] != "")
				{
					gfx.DrawText(_fonts["consolas"], _brushes["green"], 300, (i * 10) - 10, _plrNames[i] + " " + _plrRanks[i]);
				}
			}
		}

		public void Run(string[] plrName, string[] plrRank)
		{
			_plrNames = plrName;
			_plrRanks = plrRank;
			var tmphWnd = Native.FindWindow(null, "Company Of Heroes 2");
            if (tmphWnd == IntPtr.Zero)
            {
				return;
            }

			if (_window == null)
			{
				var gfx = new Graphics()
				{
					MeasureFPS = false,
					PerPrimitiveAntiAliasing = true,
					TextAntiAliasing = true
				};
				_window = new StickyWindow(tmphWnd, gfx)
				{
					FPS = 10,
					IsTopmost = true,
					IsVisible = true
				};
				_window.DestroyGraphics += _window_DestroyGraphics;
				_window.DrawGraphics += _window_DrawGraphics;
				_window.SetupGraphics += _window_SetupGraphics;
				_window.Create();
			}
			else
            {
                if (_window.ParentWindowHandle != tmphWnd)
                {
					_window.ParentWindowHandle = tmphWnd;
				}

				_window.Unpause();
				_window.Show();
			};

			Task.Delay(30000).ContinueWith(x =>
			{
				_window.Pause();
				_window.Hide();
			});
		}

		~Coh2Overlay()
		{
			Dispose(false);
		}

		#region IDisposable Support
		private bool disposedValue;

		protected virtual void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				if (_window != null )
                {
					_window.Dispose();
				}

				disposedValue = true;
			}
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

        
        #endregion
    }
}
