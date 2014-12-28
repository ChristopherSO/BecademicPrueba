using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EASendMail;

namespace BLL
{
    public class GestorCorreo
    {
        /// <summary>
        /// Metodo constructor del Gestor de envio de correos
        /// </summary>
        public GestorCorreo()
        {
        }

        /// <summary>
        /// Metodo que permite enviar correos hacia un destinatario
        /// </summary>
        /// <param name="destinatario">Correo hacia donde se enviará el mensaje.</param>
        /// <param name="asunto">Asunto que aparecerá encabezando el correo.</param>
        /// <param name="mensaje">Texto que funcionará como cuerpo del mensaje.</param>
        public string enviarCorreo(string destinatario, string asunto, string mensaje)
        {
            SmtpMail mail = new SmtpMail("TryIt");
            SmtpClient smtp = new SmtpClient();

            /**
             * Remitente del mensaje
             **/
            mail.From = "becademic@gmail.com";

            /**
             * Destinatario
             **/
            mail.To = destinatario;

            /**
             * Asunto
             **/
            mail.Subject = asunto;

            /**
             * Cuerpo del mensaje
             **/
            mail.TextBody = mensaje;

            /**
             * Servidor mediante el cual se enviara el correo
             **/
            SmtpServer server = new SmtpServer("smtp.gmail.com");

            /**
             * Puerto de acceso al servidor
             **/
            server.Port = 465;

            /**
             * Detectar SSL/TLS automaticamente
             **/
            server.ConnectType = SmtpConnectType.ConnectSSLAuto;
            server.AuthType = SmtpAuthType.AuthAuto;

            /**
             * Autenticación de Gmail \|T|/
             **/
            server.User = "becademic@gmail.com";
            server.Password = "praisethesun";

            /**
             * Envio del correo
             **/
            try
            {
                smtp.SendMail(server, mail);
            }
            /**
             * Manejo de errores
             **/
            catch (SmtpTerminatedException ex)
            {
                return "Error: " + ex.Message;
            }
            catch (SmtpServerException ex)
            {
                return "Error: " + ex.Message;
            }
            catch (System.Net.Sockets.SocketException ex)
            {
                return "Error: " + ex.Message;
            }
            catch (System.ComponentModel.Win32Exception ex)
            {
                return "Error: " + ex.Message;
            }
            catch (System.Exception ex)
            {
                return "Error: " + ex.Message;
            }

            return "true";
        }

    }
}