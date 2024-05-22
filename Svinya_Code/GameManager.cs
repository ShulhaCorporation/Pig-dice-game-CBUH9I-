using System;
public class GameManager
{   private static int turn;
    private static int playerScore;
    private static int botScore;
    private static int limit = 100;
    private static bool isCheating = false;
    public GameManager(){
        
    }
    public static int GetBot => botScore;
    public static int GetLimit => limit;
        static void Main(string[] args)
    { 
        Console.WriteLine("СВИНЯ");
        Console.WriteLine("Введіть s, щоб розпочати");
        Console.WriteLine("        r - правила гри та команди");
        Console.WriteLine("Команди писати без пробілів");
        mark:
        string choise = Console.ReadLine();
        if (choise.Equals("r"))
        {
            Console.Write("Ви граєте проти комп'ютера. Під час свого ходу ви можете кинути кубик(введіть d),\n або записати очки і передати хід супернику(введіть pass).");
            Console.WriteLine("Якщо під час кидка кості випало значення від 2 до 6, воно додається в малий рахунок. Гравець може кидати кості доти, доки він не зупиниться або поки не випаде 1.\n Якщо випала 1, малий рахунок обнулюється і гравець отримує 0 балів за весь хід. Хід передається наступному гравцеві.");
            Console.WriteLine("Якщо гравець вирішує зупинитися, очки з малого рахунку зараховуються у загальний і хід передається супернику.\n Гра завершується, коли один з учасників набирає 100 і більше очок в загальному рахунку.");
            Console.WriteLine("Команди та чіти: limit - встановити кількість очок для перемоги. Доступна лише в меню");
            Console.WriteLine("                  me  - змінити ваш загальний рахунок (чіти). Доступна лише під час гри");
            Console.WriteLine("                  bot - змінити загальний рахунок бота (чіти). Доступна лише під час гри");
            goto mark;
        }
       else if(choise.Equals("s"))
        { 
           Startin();
        }
        else if(choise.Equals("limit")){
            Console.WriteLine("Встановіть кількість очок, за якої гравець перемагає (натуральне число до 2,147,483,647)");
            string limitString = Console.ReadLine();
            int.TryParse(limitString, out limit);
            if(limit > 0){
            Console.WriteLine("Ліміт гри встановлено до "+ limit+" очок");
            goto mark;
            }
            else{
                limit = 100;
                Console.WriteLine("Некоректне значення. Операція не відбулася. Ліміт = 100 ");
                goto mark;
            }
        }
        else{
            Console.WriteLine("Команди не існує. Ознайомтеся з правилами.");
            goto mark;
        }
        
    }
    public static void Startin(){
        Console.WriteLine("Гра починається!");
        
        var rand = new Random();
        turn = rand.Next(2);
        
        if(turn == 0){
            Console.WriteLine("Ви ходите першими");
            Player.Choose();
        }
        else{
            Console.WriteLine("Бот ходить першим");
            Bot.Run();
        }
        
    }
    public static void CountPlayer(int score){
        playerScore += score;
        Console.WriteLine("Ваш загальний рахунок: "+playerScore);
        Compare();
    }
        public static void CountBot(int score){
        botScore += score;
        Console.WriteLine("Загальний рахунок суперника: "+botScore);
        Compare();
    }
    private static void Compare(){
        if(playerScore >= limit){
            if(isCheating){
                Console.WriteLine("Ви перемогли з використанням чіт-команд");
            }
            else{
            Console.WriteLine("ВИ ПЕРЕМОГЛИ!");
            }
            playerScore = 0;
            botScore = 0;
           Environment.Exit(0);
        }
        else if(botScore >= limit){
            if(isCheating){
                Console.WriteLine("Ви програли з використанням чіт-команд");
            }
            else{
            Console.WriteLine("ВИ ПРОГРАЛИ!");
            }
            playerScore = 0;
            botScore = 0;
           Environment.Exit(0);
        }
        else{
            Turn();
        }
    }
    private static void Turn(){
        //міняємо хід
        if(turn==0){
            turn = 1;
            Player.Reset();
        }
        else if(turn==1){
            turn = 0;
             Bot.Reset();
        }
    }
    public static void Continue(){
        if(turn == 0){
            
            Console.WriteLine("Ваш хід");
            Draw();
            Player.Choose();
        }
        else if(turn == 1){
            Console.WriteLine("Хід бота");
            Draw();
            Bot.Run();
        }
    }
    public static void Draw(){
        Console.Write("                                                 Ви: "+ playerScore+"/"+limit+"\n                                                Бот: "+botScore+"/"+limit+"\n");
    }
    public static void SetMe(){
        isCheating = true;
        Console.WriteLine("ЧІТИ АКТИВОВАНІ!\n Встановіть кількість ваших очок");
        string playerScoreString = Console.ReadLine();
        int.TryParse(playerScoreString, out playerScore);
        Draw();
        Player.Choose();
        }
          public static void SetBot(){
        isCheating = true;
        Console.WriteLine("ЧІТИ АКТИВОВАНІ!\n Встановіть кількість очок суперника");
        string botScoreString = Console.ReadLine();
        int.TryParse(botScoreString, out botScore);
        Draw();
        Player.Choose();
        }
}
