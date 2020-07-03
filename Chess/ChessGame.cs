using System;
using System.Windows.Forms;

namespace Chess {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    namespace Chess {
        static class ChessGame {
            [STAThread]
            static void Main() {
                new WinFromChess().Play();
            }
        }
    }

    internal class WinFromChess {
        public WinFromChess() {
        }
        internal void Play() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ChessGameForm());
        }
    }
}