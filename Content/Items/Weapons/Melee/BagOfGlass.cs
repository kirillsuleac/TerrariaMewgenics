using Mewgenics.Content.Items.Materials; // Using our Materials folder
using Mewgenics.Content.Projectiles; // Using our Projectiles folder
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Mewgenics.Content.Items.Weapons.Melee // Where is your code locates
{
    public class BagOfGlass : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1; // How many items need for research in Journey Mode
            ItemID.Sets.ToolTipDamageMultiplier[Type] = 2f;
        }

        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.Shoot; // How you use the item (swinging, holding out, etc.)
			Item.useAnimation = 45; // The item's use time in ticks (60 ticks == 1 second.)
			Item.useTime = 45; // The item's use time in ticks (60 ticks == 1 second.)
			Item.knockBack = 5.5f; // The knockback of your flail, this is dynamically adjusted in the projectile code.
			Item.width = 32; // Hitbox width of the item.
			Item.height = 32; // Hitbox height of the item.
			Item.damage = 15; // The damage of your flail, this is dynamically adjusted in the projectile code.
			Item.noUseGraphic = true; // This makes sure the item does not get shown when the player swings his hand
			Item.shoot = ModContent.ProjectileType<BagGlassProjectile>(); // The flail projectile
			Item.shootSpeed = 12f; // The speed of the projectile measured in pixels per frame.
			Item.UseSound = SoundID.Item1; // The sound that this item makes when used
			Item.rare = ItemRarityID.Green; // The color of the name of your item
			Item.value = Item.sellPrice(gold: 1, silver: 50); // Sells for 1 gold 50 silver
			Item.DamageType = DamageClass.MeleeNoSpeed; // Deals melee damage
			Item.channel = true;
			Item.noMelee = true; // This makes sure the item does not deal damage from the swinging animation

            
        }

        // Creating item craft
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient<GlassShard>(7); // We are using custom material for the craft, 7 Glass Shards
            recipe.AddIngredient(ItemID.Wood, 3); // Also, we are using vanilla material to craft, 3 Wood
            recipe.AddTile(TileID.Anvils); // Crafting station we need for craft, WorkBenches, Anvils etc. You can find them here - https://terraria.wiki.gg/wiki/Tile_IDs
            recipe.Register();
        }
    }
}