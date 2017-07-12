using System;
using System.IO.Ports;
using System.Text;
using System.Threading;

namespace ReGameVR.Device
{
	/// <summary>
	/// Serial port proxy. Serial port with basic access only.
	/// </summary>
	public class SerialPortProxy
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ReGameVR.Device.SerialPortProxy"/> class.
		/// No values assigned.
		/// </summary>
		public SerialPortProxy () {
			serialPort = new SerialPort ();
//			serialPort.DtrEnable = false;
//			serialPort.RtsEnable = false;
		}

		/// <summary>
		/// Open this connection.
		/// </summary>
		public void Open () { 
			serialPort.Open (); 
		}

		public bool TryOpen () {
			serialPort.Open ();
			return serialPort.IsOpen;
		}

		/// <summary>
		/// Close this connection.
		/// </summary>
		/// <remarks>
		/// Should wait before reopening as the connection may not close immediately
		/// </remarks>
		public void Close () { 
			if (IsOpen) { 
				Thread closeThread = new Thread (new ThreadStart (close));
				closeThread.Start ();
			}
		}

		private void close () {
			serialPort.Close (); 
		}

		/// <summary>
		/// Reads to next newline character;
		/// </summary>
		/// <returns>The line.</returns>
		public string ReadLine () {
            if (IsOpen) {
                return serialPort.ReadLine();
            }
            return "";
        }

		/// <summary>
		/// Write the specified data.
		/// </summary>
		/// <param name="data">Data.</param>
		public void Write (string data) { serialPort.Write (data); }

		/// <summary>
		/// Writes the specified data with appended newline.
		/// </summary>
		/// <param name="data">Data.</param>
		public void WriteLine (string data) { serialPort.WriteLine (data); }

		/// <summary>
		/// Discards the in buffer.
		/// </summary>
		public void DiscardInBuffer () { serialPort.DiscardInBuffer (); }

		/// <summary>
		/// Discards the out buffer.
		/// </summary>
		public void DiscardOutBuffer () { serialPort.DiscardOutBuffer (); }

		/// <summary>
		/// Discards the buffers.
		/// </summary>
		public void DiscardBuffers () {
			if (IsOpen) {
				serialPort.DiscardInBuffer ();
				serialPort.DiscardOutBuffer ();	
			}
		}

		/// <summary>
		/// Gets a value indicating whether this connection is open.
		/// </summary>
		/// <value><c>true</c> if this instance is open; otherwise, <c>false</c>.</value>
		public bool IsOpen {
			get { return serialPort.IsOpen; }
			private set { }
		}

		/// <summary>
		/// Gets or sets the name of the port.
		/// </summary>
		/// <value>The name of the port.</value>
		public string PortName {
			get { return serialPort.PortName; }
			set { serialPort.PortName = value; }
		}

		/// <summary>
		/// Gets or sets the baudrate.
		/// </summary>
		/// <value>The baudrate.</value>
		public int BaudRate {
			get { return serialPort.BaudRate; }
			set { serialPort.BaudRate = value; }
		}

		/// <summary>
		/// Gets or sets the text encoding.
		/// </summary>
		/// <value>The encoding.</value>
		public Encoding Encoding {
			get { return serialPort.Encoding; }
			set { serialPort.Encoding = value; }
		}

		/// <summary>
		/// Gets or sets the read timeout in milliseconds.
		/// </summary>
		/// <value>The read timeout in milliseconds.</value>
		public int ReadTimeout {
			get { return serialPort.ReadTimeout; }
			set { serialPort.ReadTimeout = value; }
		}

		/// <summary>
		/// Gets or sets the write timeout in milliseconds..
		/// </summary>
		/// <value>The write timeout in milliseconds.</value>
		public int WriteTimeout {
			get { return serialPort.WriteTimeout; }
			set { serialPort.WriteTimeout = value; }
		}

		protected SerialPort serialPort;
	}
}

