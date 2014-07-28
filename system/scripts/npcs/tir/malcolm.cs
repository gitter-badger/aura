//--- Aura Script -----------------------------------------------------------
// Malcolm
//--- Description -----------------------------------------------------------
// General store manager
//---------------------------------------------------------------------------

public class MalcolmBaseScript : NpcScript
{
	public override void Load()
	{
		SetName("_malcolm");
		SetRace(10002);
		SetBody(upper: 1.1f); //not updated
		SetFace(skinColor: 20); //not updated
		SetStand("human/male/anim/male_natural_stand_npc_malcolm_retake", "human/male/anim/male_natural_stand_npc_malcolm_talk");
		SetLocation(8, 1235, 1656, 60); //not exact values

		EquipItem(Pocket.Face, 4900, 0xF88B4A); //not updated
		EquipItem(Pocket.Hair, 4154, 0x4D4B53); //not updated
		EquipItem(Pocket.Armor, 15652, 0xAC9271, 0x4D4F48, 0x7C6144); //not updated
		EquipItem(Pocket.Shoe, 17012, 0x9C7D6C, 0xFFC9A3, 0xF7941D); //not updated
		EquipItem(Pocket.LeftHand1, 40012, 0xDCDCDC, 0xC08B48, 0x808080); //not updated

        AddPhrase("Maybe I should wrap it up and call it a day...");
        AddPhrase("Aww! My legs hurt. My feet are all swollen from standing all day long.");
        AddPhrase("I wonder what Nora is doing now...");
        AddPhrase("These travelers will buy something sooner or later.");
	}
	
	protected override async Task Talk()
	{
		SetBgm("NPC_Malcolm.mp3");
	
		await Intro(
			"While his thin face makes him look weak,",
			"and his soft and delicate hands seem much too feminine,",
			"his cool long blonde hair gives him a suave look.",
            "He looks like he just came out of a workshop since he's wearing a heavy leather apron."
		);
		
		Msg("What can I do for you?", Button("Start a Conversation", "@talk"), Button("Shop", "@shop"), Button("Repair Item", "@repair"));
		
		switch(await Select())
		{
			case "@talk":
                //Msg("Welcome to the General Shop. This must be your first visit here.");
				Msg("Thank you for coming again.");
                //Msg("Thank you for visiting again, <username/>.<br/>If you come and shop here regularly,<br/>I will treat you as a VIP customer. Ha ha.");
                //Alternate message as you talk to him more? Apparently it logs your visits at least to this shop
                await StartConversation();
				return;
				
			case "@shop":
				Msg("Welcome to Malcolm's General Shop.<br/>Look around as much as you wish. Clothes, accessories and other goods are in stock.");
				Msg("(Unimplemented)");
				return;
				
			case "@repair":
				Msg("What item do you want to repair?<br/>You can repair various items such as Music Instruments and Glasses.");
				Msg("(Unimplemented)");
                //Next message happens after you close repair window
                //Msg("Let me give you a tip.<br/>If you bless your item with Holy Water of Lymilark,<br/>you can reduce abrasion which means your item will wear off more slowly over time.");
				return;

			default:
				Msg("...");
				return;
		}
	}
	
	protected override async Task Keywords(string keyword)
	{
		switch (keyword)
		{
            case "personal_info":
                Msg("I run this General Shop. I sell various goods.");
                break;

            case "rumor":
                Msg("Tir Chonaill is a peaceful town.<br/>So when something happens, everyone in the town knows right away.<br/>I warn you, some were humiliated because of that...<br/>Nothing is as important as being responsible for your own actions.<p/>If you behave like Tracy, you'll be in big trouble.");
                break;

            case "about_skill":
                Msg("If you are interested in music skills,<br/>why don't you buy the 'Introduction to Composing Tunes' in my shop?<p/>I try to have as many as possible in stock,<br/>but it's not easy to bring books to a rural town.<p/>There is a Bookstore in Dunbarton.<br/>So if you're looking for books on music, go there.");
                break;

            case "about_arbeit":
                Msg("Sorry, but it is not time for part-time jobs.<br/>Would you come later?");
                //Msg("Our town may be small, but running the General Shop<br/>can really get hectic since I'm running this all by myself.<br/>Fortunately, many people are helping me out, so it's a lot easier for me to handle.<br/>Are you also interested in working here, <username/>?<p/>I'll pay you if you can help me.");
                break;

            case "shop_misc":
                Msg("Yes, this is Malcolm's General Shop.");
                break;

            case "shop_grocery":
                Msg("The Grocery Store is right across from here.<br/>Caitin is such an honest, meticulous person<br/>that she only sells fresh goods. You should absolutely pay her a visit.<p/>A one-sided diet is bad for your health<br/>so pick your food wisely.");
                break;

            case "shop_bank":
                Msg("That's the place where Bebhinn works. I know she's an excellent worker,<br/>but I don't trust her...<p/>She gossips about other people too much<br/>and often doesn't tell you when you forget about your deposited items.");
                break;

            case "shop_smith":
                Msg("Many people seem to be confusing the General Shop with the Blacksmith's Shop.<br/>I sell general goods, and Ferghus usually sells<br/>weapons or armor made from iron.<br/>His shop is near the Adelia Stream at the entrance of town.");
                break;

            case "skill_counter_attack":
                Msg("Um... I don't know what it is,<br/>but it sounds like a combat skill.<br/>How about asking Ranald at the School?<p/>I'm sure he'll be a lot more helpful than me.");
                break;

            case "square":
                Msg("...<br/>Are you joking?<br/>You ask me where the Square is when it's just out the door?<p/>Um... Do I look so naive?<br/>Maybe I should change my hairstyle...");
                break;

            case "farmland":
                Msg("The farmland is near the School.<br/>How come so many travelers are interested in it?<br/>There's nothing special about it.<p/>What's more, their careless strolls through the farmland<br/>are damaging the crops...");
                break;

            case "shop_headman":
                Msg("The Chief's House? It's on the hill over there.<br/>If your eyesight is good, you can see it from here.<p/>If you can't remember it, think of it this way...<br/>A person of a high position lives in a high location.");
                break;

            case "temple":
                Msg("So, you want to go to the Church?<br/>Let's see... Go down a bit from the Bank over there,<br/>and you can't miss it.<p/>Could you tell Priest Meven that I have lots of high-quality candlesticks when you get there?<br/>You can tell Priestess Endelyon instead<br/>if he's not there.");
                break;

            case "skill_campfire":
                Msg("Beats me. Why would someone<br/>build a campfire<br/>when they could just stay inside a house?<p/>Things could go wrong and you could burn down the entire forest, you know.");
                break;

            case "shop_restaurant":
                Msg("Have you visited the Grocery Store next door?<br/>There aren't any restaurants in town, but any food can be bought at the Grocery Store.<br/>So we don't feel it's an inconvenience.<p/>And, after all,<br/>Caitin is an excellent cook.");
                break;

            case "shop_armory":
                Msg("Weapons Shop? Well...<br/>If you're looking for weapons, try the Blacksmith's Shop.<br/>There aren't any Weapon Shops in this town.<p/>Is it just me? Or are you trying to boast about<br/>having come from a city?");
                break;

            case "shop_goverment_office":
                Msg("Um... you can't find such a thing in a country town like this. Expect to find it in a big city.<br/>And this is an autonomous district<br/>protected by Ulaid, descendants of Partholon.<p/>What was it...<br/>Some people said they have to go to the Town Office to find their lost items.<br/>If that's the case, you can go ask Chief Duncan.<p/>He greets new adventurers,<br/>takes care of a weird cat,<br/>and returns lost items.<br/>He lives a busy life indeed.");
                break;

			default:
				RndMsg(
					"I don't know.",
                    "Hm... Beats me.",
                    "Well... I don't have much to say about it.",
                    "I think I heard about it but... I can't remember.",
                    "Sorry, I don't know.<br/>Hm... Maybe I should have a travel diary to write things down."
				);
				break;
		}
	}
}
