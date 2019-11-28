using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_App
{
    class Quiz
    {
        private string[,] questions = new string[20, 5];
        public Quiz()
        {
            questions[0, 0] = "Đâu là vị tướng có tầm đánh cơ bản xa nhất LOL?";
            questions[0, 1] = "Twitch";
            questions[0, 2] = "Tristana";
            questions[0, 3] = "*Caitlyn";
            questions[0, 4] = "Kog’Maw";
            //
            questions[1, 0] = "“PET” của vị tướng LOL nào có thời gian tồn tại lâu nhất?";
            questions[1, 1] = "Daisy";
            questions[1, 2] = "*Yorick ";
            questions[1, 3] = "Shaco";
            questions[1, 4] = "Tibber";
            //
            questions[2, 0] = "Khi max lv, chiêu thức nào có tầm sử dụng xa nhất?";
            questions[2, 1] = "*Định Mệnh";
            questions[2, 2] = "Siêu Hùng Giáng Thế";
            questions[2, 3] = "Hoang Tưởng";
            questions[2, 4] = "Thiên Mệnh Khả Biến";
            //
            questions[3, 0] = "Rek’Sai có thể tạo được tối đa bao nhiêu đường hầm cùng một thời điểm?";
            questions[3, 1] = "*8";
            questions[3, 2] = "7";
            questions[3, 3] = "9";
            questions[3, 4] = "6";
            //
            questions[4, 0] = "Trong 4 kỹ năng dưới đây, kỹ năng của ai có thời gian áp chế lâu nhất?";
            questions[4, 1] = "Urgot";
            questions[4, 2] = "Warwick";
            questions[4, 3] = "*Malzahar";
            questions[4, 4] = "Skarner";
            //
            questions[5, 0] = "Đâu là tướng có cơ chế Ngụy Trang?";
            questions[5, 1] = "Talon";
            questions[5, 2] = "*Twitch";
            questions[5, 3] = "Vayne";
            questions[5, 4] = "Kha’Zix";
            //
            questions[6, 0] = "Đâu là tướng không có khả năng gây sát thương chuẩn?";
            questions[6, 1] = "Cho’Gath";
            questions[6, 2] = "*Volibear";
            questions[6, 3] = "Ahri";
            questions[6, 4] = "Camille";
            //
            questions[7, 0] = "(W) của Heimerdinger bắn ra bao nhiêu quả tên lửa?";
            questions[7, 1] = "6";
            questions[7, 2] = "4";
            questions[7, 3] = "7";
            questions[7, 4] = "*5";
            //
            questions[8, 0] = "Caitlyn có nghề tay trái là gì?";
            questions[8, 1] = "Cầu thủ";
            questions[8, 2] = "Lính đánh thuê";
            questions[8, 3] = "Khoa học gia";
            questions[8, 4] = "*Viết tiểu thuyết";
            //
            questions[9, 0] = "Kẻ thù của Trydamere là ai?";
            questions[9, 1] = "*Sejuani";
            questions[9, 2] = "Yasuo";
            questions[9, 3] = "Ashe";
            questions[9, 4] = "Master Yi";
            //
            questions[10, 0] = "Yasuo thuộc xứ nào?";
            questions[10, 1] = "Demacia";
            questions[10, 2] = "Noxus";
            questions[10, 3] = "Piltover";
            questions[10, 4] = "*Ionia";
            //
            questions[11, 0] = "Vladimir hút máu hay hồi máu";
            questions[11, 1] = "Cả 2 đều đúng";
            questions[11, 2] = "Cả 2 đều sai";
            questions[11, 3] = "Hút máu";
            questions[11, 4] = "*Hồi máu";
            //
            questions[12, 0] = "Tướng nào vừa trói, làm chậm, đẩy lùi, hất tung?";
            questions[12, 1] = "Thresh";
            questions[12, 2] = "Blitzcrank";
            questions[12, 3] = "Sylas";
            questions[12, 4] = "*Maokai";
            //
            questions[13, 0] = "Nekko crush ai?";
            questions[13, 1] = "Ezreal";
            questions[13, 2] = "Taric";
            questions[13, 3] = "Zoe";
            questions[13, 4] = "*Nidalee";
            //
            questions[14, 0] = "Tường gió Yasuo tồn tại bao lâu?";
            questions[14, 1] = "7";
            questions[14, 2] = "6";
            questions[14, 3] = "5";
            questions[14, 4] = "*4";
            //
            questions[15, 0] = "Trong Varus tồn tại bao nhiêu linh hồn?";
            questions[15, 1] = "4";
            questions[15, 2] = "2";
            questions[15, 3] = "5";
            questions[15, 4] = "*3";
        }
        public string getQuestion(int i)
        {
            return questions[i, 0];
        }
        public string getAnswer(int i, int j)
        {
            return questions[i, j];
        }

    }
}
