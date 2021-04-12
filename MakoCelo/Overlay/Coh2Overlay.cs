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
		private IntPtr _hWnd;

		private StickyWindow _window;

		private readonly Dictionary<string, SolidBrush> _brushes;
		private readonly Dictionary<string, Font> _fonts;
		private readonly Dictionary<string, Image> _images;
		private string[] _plrNames;
		private string[] _plrRanks;

		private Geometry _gridGeometry;
		private Rectangle _gridBounds;

		private Random _random;

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

			_brushes["black"] = gfx.CreateSolidBrush(0, 0, 0);
			_brushes["white"] = gfx.CreateSolidBrush(255, 255, 255);
			_brushes["red"] = gfx.CreateSolidBrush(255, 0, 0);
			_brushes["green"] = gfx.CreateSolidBrush(0, 255, 0);
			_brushes["blue"] = gfx.CreateSolidBrush(0, 0, 255);
			_brushes["background"] = gfx.CreateSolidBrush(0x33, 0x36, 0x3F,0);
			_brushes["grid"] = gfx.CreateSolidBrush(255, 255, 255, 0.2f);
			_brushes["random"] = gfx.CreateSolidBrush(0, 0, 0);

			if (e.RecreateResources) return;

			_fonts["arial"] = gfx.CreateFont("Arial", 12);
			_fonts["consolas"] = gfx.CreateFont("Consolas", 14);

			_gridBounds = new Rectangle(20, 60, gfx.Width - 20, gfx.Height - 20);
			_gridGeometry = gfx.CreateGeometry();

			for (float x = _gridBounds.Left; x <= _gridBounds.Right; x += 20)
			{
				var line = new Line(x, _gridBounds.Top, x, _gridBounds.Bottom);
				_gridGeometry.BeginFigure(line);
				_gridGeometry.EndFigure(false);
			}

			for (float y = _gridBounds.Top; y <= _gridBounds.Bottom; y += 20)
			{
				var line = new Line(_gridBounds.Left, y, _gridBounds.Right, y);
				_gridGeometry.BeginFigure(line);
				_gridGeometry.EndFigure(false);
			}

			_gridGeometry.Close();

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

            for (int i = 0; i < _plrNames.Length; i++)
            {
				gfx.DrawTextWithBackground(_fonts["consolas"], _brushes["green"], _brushes["black"], 58, 40 + i * 20, _plrNames[i] + " " + _plrRanks[i]);
            }
		}

		private SolidBrush GetRandomColor()
		{
			var brush = _brushes["random"];

			brush.Color = new Color(_random.Next(0, 256), _random.Next(0, 256), _random.Next(0, 256));

			return brush;
		}

		public void Run(string[] plrName, string[] plrRank)
		{
			_plrNames = plrName;
			_plrRanks = plrRank;
			var processes = Process.GetProcessesByName("RelicCoH2");
			if (processes.Length > 0)
			{
				if (_window == null)
				{
					var gfx = new Graphics()
					{
						MeasureFPS = false,
						PerPrimitiveAntiAliasing = true,
						TextAntiAliasing = true
					};
					_hWnd = Native.FindWindow(null, "Company Of Heroes 2");
					Native.RECT x;
					Native.GetWindowRect(_hWnd, out x);
					_window = new StickyWindow(x.Left, x.Top, x.Right - x.Left, x.Bottom - x.Top, _hWnd, gfx)
					{
						FPS = 10,
						IsTopmost = true,
						IsVisible = true
					};
					_window.DestroyGraphics += _window_DestroyGraphics;
					_window.DrawGraphics += _window_DrawGraphics;
					_window.SetupGraphics += _window_SetupGraphics;
				}

				if (!_window.IsInitialized)
				{
					_window.Create();
				}
				else
				{
					_window.Unpause();
					_window.Show();
				}
			}
			Task.Delay(30000).ContinueWith(x =>
			{
				this.Pause();
			});
		}
		internal void Pause()
		{
			_window.Pause();
			_window.Hide();
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
