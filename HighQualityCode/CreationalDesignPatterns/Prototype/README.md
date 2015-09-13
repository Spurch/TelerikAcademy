#Създаващи шаблони - Прототип (Prototype)
	1. ##Мотивация:
		Прототип е един от най-полезните създаващи шаблони и идеята зад него е учудващо проста - да използваме даден набор от готови заготовки/рамки на обекти(*Прототипи), които да клонираме когато искаме да създадем нов обект от даден *клас, вместо всеки път да правим нова *инстанция на обект от съответния клас. Използването на този подход ни дава няколко ключови предимства:
		- Енкапсулиране и скриване на конкретната реализация зад Прототипа (подобно на шаблона Фабрика).
		- Потенциално редуциране на броя на класове посредством обединяването на обекти със сходни характеристики в общ **Прототип.
		- Спестяваме си постоянната инициализация на нови обекти чрез *new.
		- Повечето модерни Обектно-ориентирани езици имат заложена в себе си идеята на Прототип. 
		Потенциални проблеми:
		- Създаването на нови обект от прототипи изисква надеждно *дълбоко копиране на прототипа в новия обект за да гарантираме, че няма да имаме два обекта достъпващи една и съща памет.
	
	2. ##Структура:
		![](https://raw.githubusercontent.com/Spurch/TelerikAcademy/master/HighQualityCode/CreationalDesignPatterns/Prototype/Prototype_Pattern.jpg)
	
	3. ##Имплементация:
		Да вземем за пример една социална мрежа в която потребителите могат да споделят статуси. Един статус може да бъде снимка с/без текст, видео с/без текст или просто текст. Като всеки потребител може да харесва даден статус. Така погледнато всеки един статус ще разполага с следните (най-базови) характеристики:
		- ID генерирано от системата.
		- заглавие.
		- автор.
		- дата.
		- брой харесвания.
		- снимка/видео/текст.
		Ясно се вижда, че може да използваме готови Прототипи за различните видове статуси вместо постоянно да създаваме нови обекти. Още повече - може да обобщим трите вида статуси в един общ Прототип и по този начин даже да редуцираме броя на класовете, с които трябва да работим. Но нека да видим един по-базов пример.
	
	4. ##Примерен код:
		```
		public abstract class StatusPrototype
		{
			private string statusId;
			private string statusTitle;
			private string statusAuthor;
			private Date shareDate;
			private unsigned int statusLikes;
			
			private StatusPrototype(){}
			
			private StatusPrototype(string id, string title, string author, Date date, unsigned int likes)
			{
				
			}
			
			public string Id
			{
				get
				{
					return statusId;
				}
				set
				{
					statusId = value;
				}
			}
			public string Title
			{
				get
				{
					return statusTitle;
				}
				set
				{
					statusTitle = value;
				}
			}
			public string Author
			{
				get
				{
					return statusAuthor;
				}
				set
				{
					statusAuthor = value;
				}
			}
			public Date ShareDate
			{
				get
				{
					return shareDate;
				}
				set
				{
					shareDate = value;
				}
			}
			public unsigned int Likes			{
				get
				{
					return statusLikes;
				}
				set
				{
					statusLikes = value;
				}
			}
			
			public abstract StatusPrototype clone();
		}
		
		public class ImagePrototype : StatusPrototype
		{
			/*
			* Some image specific logic.
			*/
			
			public override StatusPrototype clone()
			{
				return (StatusPrototype)this.MemberwiseClone();
			}
		}
		
		public class VideoPrototype : StatusPrototype
		{
			/*
			* Some video specific logic.
			*/
		
			public override StatusPrototype clone()
			{
				return (StatusPrototype)this.MemberwiseClone();
			}
		}
		
		public class TextPrototype : StatusPrototype
		{
			/*
			* Some text specific logic.
			*/
			
			public override StatusPrototype clone()
			{
				return (StatusPrototype)this.MemberwiseClone();
			}
		}
		```
