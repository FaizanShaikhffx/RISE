namespace GuestHouseBooking.Services
{
    public static class EmailTemplates
    {
        private static string GetBaseHtml(string title, string content)
        {
            return $@"
            <!DOCTYPE html>
            <html>
            <head>
                <style>
                    body {{ font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; background-color: #f3f4f6; margin: 0; padding: 0; }}
                    .container {{ max-width: 600px; margin: 40px auto; background-color: #ffffff; border-radius: 12px; overflow: hidden; box-shadow: 0 4px 6px rgba(0,0,0,0.1); }}
                    .header {{ background: linear-gradient(135deg, #6D28D9 0%, #8B5CF6 100%); padding: 30px; text-align: center; color: white; }}
                    .header h1 {{ margin: 0; font-size: 24px; font-weight: 700; letter-spacing: 1px; }}
                    .content {{ padding: 40px 30px; color: #374151; line-height: 1.6; }}
                    .highlight-box {{ background-color: #f5f3ff; border-left: 4px solid #7c3aed; padding: 15px; margin: 20px 0; border-radius: 4px; }}
                    .footer {{ background-color: #f9fafb; padding: 20px; text-align: center; font-size: 12px; color: #9ca3af; border-top: 1px solid #e5e7eb; }}
                    .button {{ display: inline-block; background-color: #6D28D9; color: white; padding: 12px 24px; text-decoration: none; border-radius: 6px; font-weight: 600; margin-top: 20px; }}
                    .label {{ font-weight: 600; color: #4b5563; }}
                    .value {{ color: #111827; font-weight: 500; }}
                </style>
            </head>
            <body>
                <div class='container'>
                    <div class='header'>
                        <h1>Guesthouse Booking</h1>
                    </div>
                    <div class='content'>
                        <h2 style='color: #111827; margin-top: 0;'>{title}</h2>
                        {content}
                    </div>
                    <div class='footer'>
                        <p>&copy; {DateTime.Now.Year} Guesthouse Booking System. All rights reserved.</p>
                        <p>This is an automated message, please do not reply.</p>
                    </div>
                </div>
            </body>
            </html>";
        }

        public static string WelcomeEmail(string userName, string email, string password)
        {
            string content = $@"
                <p>Hello <strong>{userName}</strong>,</p>
                <p>Welcome to the team! Your account has been successfully created by the administrator.</p>
                
                <div class='highlight-box'>
                    <p style='margin: 0 0 10px 0;'><span class='label'>Username:</span> <span class='value'>{email}</span></p>
                    <p style='margin: 0;'><span class='label'>Temporary Password:</span> <span class='value'>{password}</span></p>
                </div>

                <p>Please log in immediately and change your password to something secure.</p>
                
                <div style='text-align: center;'>
                    <a href='http://localhost:4200/login' class='button' style='color: white;'>Login to Portal</a>
                </div>";

            return GetBaseHtml("Welcome Aboard!", content);
        }

        public static string OtpEmail(string otp)
        {
            string content = $@"
                <p>We received a request to reset your password.</p>
                <p>Use the following One-Time Password (OTP) to complete the process. This code is valid for <strong>10 minutes</strong>.</p>
                
                <div style='text-align: center; margin: 30px 0;'>
                    <span style='font-size: 32px; font-weight: 700; letter-spacing: 5px; color: #6D28D9; background: #f3f4f6; padding: 10px 20px; border-radius: 8px; border: 1px dashed #6D28D9;'>{otp}</span>
                </div>

                <p>If you did not request this, please ignore this email.</p>";

            return GetBaseHtml("Password Reset Request", content);
        }

        public static string NewBookingNotification(int bookingId, string userName, string guesthouse, string room, string bed, DateTime from, DateTime to)
        {
            string content = $@"
                <p>A new booking request has been submitted and requires your approval.</p>
                
                <div class='highlight-box'>
                    <p style='margin: 5px 0;'><span class='label'>User:</span> <span class='value'>{userName}</span></p>
                    <p style='margin: 5px 0;'><span class='label'>Property:</span> <span class='value'>{guesthouse}</span></p>
                    <p style='margin: 5px 0;'><span class='label'>Room/Bed:</span> <span class='value'>{room} / {bed}</span></p>
                    <p style='margin: 5px 0;'><span class='label'>Dates:</span> <span class='value'>{from:MMM dd, yyyy} - {to:MMM dd, yyyy}</span></p>
                </div>

                <div style='text-align: center;'>
                    <a href='http://localhost:4200/admin/bookings' class='button' style='color: white;'>Review Booking</a>
                </div>";

            return GetBaseHtml($"New Booking #{bookingId}", content);
        }
    }
}
