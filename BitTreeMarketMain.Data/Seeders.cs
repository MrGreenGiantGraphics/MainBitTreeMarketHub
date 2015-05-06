using BitTreeMarketMain.Model;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitTreeMarketMain.Data
{
    public static class Seeders
    {
        public static void seed(BitTreeMarketDbContext db)
        {
            // generic Identity - Store the users
            UserStore<ApplicationUser> userStore = new UserStore<ApplicationUser>(db);
            UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(userStore);

            // generic Identity - roles
            RoleStore<Role> roleStore = new RoleStore<Role>(db);
            RoleManager<Role> roleManager = new RoleManager<Role>(roleStore);

            // seed data users...
            ApplicationUser userOne = null;
            userOne = userManager.FindByName("johnrodgers@email.com");

            // if USER_ONE does not exist, do create them
            if (userOne == null)
            {
                userManager.Create(new ApplicationUser
                {
                    Email = "johnrodgers@email.com",
                    FirstName = "John",
                    LastName = "Rodgers",
                    City = "San Francisco",
                    State = "California",
                    Zipcode = "94101",
                    Country = "USA",
                    BitAddress = "BitCoinAddress",
                    ImageLink = "ImageURL",
                    UserName = "johnrodgers@email.com"
                }, "123456");
                userOne = userManager.FindByName("johnrodgers@email.com");
            }

            ApplicationUser userTwo = null;
            userTwo = userManager.FindByName("katefields@email.com");
            // if USER_TWO does not exist, do create them
            if (userTwo == null)
            {
                userManager.Create(new ApplicationUser
                {
                    Email = "katefields@email.com",
                    FirstName = "Kate",
                    LastName = "Fields",
                    City = "San Diego",
                    State = "California",
                    Zipcode = "92093",
                    Country = "USA",
                    BitAddress = "BitCoinAddress",
                    ImageLink = "ImageURL",
                    UserName = "katefields@email.com"
                }, "123456");
                userTwo = userManager.FindByName("katefields@email.com");
            }

            ApplicationUser userThree = null;
            userThree = userManager.FindByName("carmenpaul@email.com");

            // if USER_ONE does not exist, do create them
            if (userThree == null)
            {
                userManager.Create(new ApplicationUser
                {
                    Email = "carmenpaul@email.com",
                    FirstName = "Carmen",
                    LastName = "Paul",
                    City = "Houston",
                    State = "Texas",
                    Zipcode = "77001",
                    Country = "USA",
                    BitAddress = "BitCoinAddress",
                    ImageLink = "ImageURL",
                    UserName = "carmenpaul@email.com"
                }, "123456");
                userThree = userManager.FindByName("carmenpaul@email.com");
            }



            // if ROLES does not exist, do create them
            if (!roleManager.Roles.Any())
            {
                roleManager.Create(new Role { Name = "Admin" });
                roleManager.Create(new Role { Name = "Guest" });
                roleManager.Create(new Role { Name = "Partner" });
            }

            // assign the userOne into a role
            if (!userManager.IsInRole(userOne.Id, "Admin"))
            {
                userManager.AddToRole(userOne.Id, "Admin");
            }
            // assign the userTwo into a role
            if (!userManager.IsInRole(userTwo.Id, "Guest"))
            {
                userManager.AddToRole(userTwo.Id, "Guest");
            }
            // assign the userThree into a role
            if (!userManager.IsInRole(userThree.Id, "Partner"))
            {
                userManager.AddToRole(userThree.Id, "Partner");
            }
            //Seed the PaymentOptions 
            if (!db.PaymentOptions.Any())
            {
                db.PaymentOptions.AddOrUpdate(
                    new PaymentOption() { PaymentOptionId = 1, PaymentType = "BitCoin" },
                    new PaymentOption() { PaymentOptionId = 2, PaymentType = "Credit Card" },
                    new PaymentOption() { PaymentOptionId = 3, PaymentType = "PayPal" },
                    new PaymentOption() { PaymentOptionId = 4, PaymentType = "FIAT" },
                    new PaymentOption() { PaymentOptionId = 5, PaymentType = "Pick Up Order" });
            }

            // Seed the Categories 
            if (!db.Categories.Any())
            {
                db.Categories.AddOrUpdate(
                    new Category() { CategoryId = 1, CategoryName = "Whole Food" },
                    new Category() { CategoryId = 2, CategoryName = "Eco Fashion and Fabrics" },
                    new Category() { CategoryId = 3, CategoryName = "Eco Crafts" },
                    new Category() { CategoryId = 4, CategoryName = "Eco Friendly Services" },
                    new Category() { CategoryId = 5, CategoryName = "Home Gardening and Seeds" });
            }
            if (!db.Corporations.Any())
            {
                db.Corporations.AddOrUpdate(
                    new Corporation() { CorporationId = 1, Name = "Wipro", Country = "Brazil", Detail = "Global information technology, consulting and outsourcing company" },
                    new Corporation() { CorporationId = 2, Name = "Bradesco", Country = "Brazil", Detail = "Sustainable finance, responsible management and social-environmental investments" },
                    new Corporation() { CorporationId = 3, Name = "Whole Foods Market", Country = "United States", Detail = "Global information technology, consulting and outsourcing company" },
                    new Corporation() { CorporationId = 5, Name = "AguaClara", Country = "United States", Detail = "One-of-a-kind, community-scale water treatment technologies" },
                    new Corporation() { CorporationId = 6, Name = "Alter Eco", Country = "United States", Detail = "Alter Eco is a values-based brand of specialty food products that brings sustainable, Fair Trade and Organic Foods." },
                    new Corporation() { CorporationId = 7, Name = "Andean Naturals, Inc.", Country = "United States", Detail = " Facilitates the growth of the organic and fair-trade quinoa" },
                    new Corporation() { CorporationId = 8, Name = "Archi's Acres", Country = "United States", Detail = " Certified organic greenhouse operation, which grows living basil, kale, and other herbs and produce." },
                    new Corporation() { CorporationId = 9, Name = "Atayne, LLC", Country = "United States", Detail = " High performing outdoor and athletic apparel for activities such as running, cycling, and cross-country skiing. " },
                    new Corporation() { CorporationId = 10, Name = "Bazzani Building Company", Country = "United States", Detail = "The firm continually balances the aspects of economic viability, social responsibility, and environmental integrity in all they do." },
                    new Corporation() { CorporationId = 11, Name = "CDI", Country = "Brazil", Detail = " Affiliates cybercafes to work in partnership as a channel to distribute products and services focused on education and financial inclusion" },
                    new Corporation() { CorporationId = 12, Name = "Clean Ethics", Country = "United States", Detail = " Products are changing the way people sanitize these hard to clean drinking vessels by providing a solution that is safe" },
                    new Corporation() { CorporationId = 13, Name = "The Honest Life ", Country = "United States", Detail = " Jessica Alba wanted to create the safest, healthiest environment for her family. But she was frustrated by the lack of trustworthy information on how to live healthier and cleaner-delivered in a way that a busy mom could act on without going to extremes." });
            }

            if (!db.Ratings.Any())
            {
                db.Ratings.AddOrUpdate(new Rating { Score = 5, Review = "Loved it" });
            }


            //------------------PRODUCTS-------------///

            if (!db.Products.Any())
            {
                //---------Honest Company------------//
                db.Products.AddOrUpdate(
                    new Product() { CategoryId = 3, ImageLink = "BabyPowder2.jpg", Name = "Organic Baby Powder", Details = "Certified organic formula keeps skin feeling soft, dry & comfortable Corn starch & kaolin clay absorb moisture – without the use of harmful talc Aloe vera soothes irritated, itchy skin & arrowroot powder has natural anti-bacterial properties Infused with probiotics to help keep skin balanced & healthy All Natural • Talc-Free • Hypoallergenic • Ultra Absorbent • Plant-Based • Non-Toxic • Safe • Pediatrician-Tested. Keep your baby's bum delightfully dry — naturally, safely & super easily! Our talc-free organic powder naturally absorbs moisture & soothes & calms skin for happy, healthy bums.", GMO = false, Price = 100.22, Quantity = 100, CorporationId = 12 },

                    new Product() { CategoryId = 3, ImageLink = "CottonBlacket.jpg", Name = "Cotton Blanket", Details = "Our meticulously handcrafted, organic cotton knit throw and receiving blanket is a treasure for any bundle of joy. A timeless classic to be passed on to future generations. It’s sweet, gentle, soft, and perfect for wrapping, cuddling, nursing, napping, and general comfort-making.The Honest Company", GMO = false, Price = 100.22, Quantity = 100, CorporationId = 12 },

                    new Product() { CategoryId = 3, ImageLink = "HealthyChild.jpg", Name = "Healthy Child", Details = "Advice on preparing a nontoxic nursery for a new baby What every expectant mom needs to do to have a safer pregnancy Clarifying which plastics and baby products to avoid and the healthier solutions Tips to take to the grocery store, including the most and least pesticide-laden fruits and vegetables and the best healthy kid-approved snacks Which beauty care / cosmetic products pose the biggest risk to health The best recipes for healthy snacks, low-cost and safe homemade cleaners, and non-toxic art supplies How to easily minimize allergens, dust, and lead A greener garden, yard, and outdoor spaces Tips to keep your pets healthy, and the unwanted pests out naturally Renovation ideas, naturally fresher indoor air, and safer sleeping options A 27 page extensive shopper's guide to the most trusted and best products every home needs Inside is also packed with over 40 featured contributions from renowned doctors, environmental scientists, and public-health experts like Dr. Harvey Karp, Dr Philip Landrigan, and William McDonough, as well as many celebrity parents like Gwyneth Paltrow, Tobey Maguire, Sheryl Crow, Erin Brockovich and Tom Hanks. A special featured contribution from First Lady Michelle Obama on her best ways of coping with her daughter's asthma. Written by Honest Company co-Founder Christopher Gavigan, Healthy Child Healthy World is the essential guide for parents. All parents want a happy and healthy child in a safe home, but where do they start? It starts with the small steps to creating a healthier, less toxic, and more environmentally sound home and this is the definitive book to get you there. Unfortunately, tens of millions of Americans, overwhelmingly children, now face chronic disease and illnesses including cancer, autism, asthma, allergies, birth defects, ADD/ADHD, obesity/diabetes, and learning and developmental disabilities. The number gets higher each year and more parents ask WHY? Scientific evidence increasingly finds chemicals in everyday products like cleaning supplies, beauty care and cosmetics, home furnishings, plastics, food, and even toys that are contributors to these ailments. The good news is that you can something to protect your children with a few simple changes! Inside, you'll find practical, inexpensive, and easy lifestyle advice for every stage of parenting. For more information about this product, check out TheHonestCompany.com", GMO = false, Price = 100.22, Quantity = 100, CorporationId = 12 },

                    new Product() { CategoryId = 3, ImageLink = "ImmunityDefenseProduct.jpg", Name = "Immunity Defense", Details = "Let’s face it – no one wants to feel 'under the weather.' Our ultra pure Immunity Defense formulation is made from concentrated and natural botanical extracts. The unique blend features Arabinogalactan, Black Elderberry, Self Heal Herb, and more – ingredients that help maintain and support healthy immune system function. Active Ingredients. Made with naturally-derived botanical ingredients which may help support healthy immune system function.For more information about this product, check out TheHonestCompany.com", GMO = false, Price = 100.22, Quantity = 100, CorporationId = 12 },

                    new Product() { CategoryId = 3, ImageLink = "LaundryDetergent2.jpg", Name = "Laundry Detergent", Details = "Cleans stubborn stains, dirt, food, and life's unexpected messes – all with a neutral pH (non-irritating to skin & does not discolor clothing). Exceptional stain removal, while guarding colors. Rinses thoroughly, leaving textiles softer, brighter, and truly clean. Suitable for ALL your family's laundry – all natural & synthetic washables, including cloth diapers, hand-washing wools, silks, and other fine washables. Perfect for babies & sensitive skin – without chemicals residues left behind. Naturally Non-Toxic • Hypoallergenic • Biodegradable • pH BalancedThe Honest Company", GMO = false, Price = 100.22, Quantity = 100, CorporationId = 12 },

                    new Product() { CategoryId = 3, ImageLink = "OrganicCottonBabyCarrier2.jpg", Name = "Organic Cotton Baby Carrier", Details = "Every parent is on the go (especially to show off that beautiful baby), so you’ll love our new baby carriers — ultra versatile, comfortable, lightweight, and super easy to use. Created from GOTS Certified Organic Cotton and Repreve®, a unique fiber made from recycled bottles, our baby carriers are crafted with sustainability top of mind.An award-winning, safety-tested, and patented design gives you the flexibility to wear your baby in 4 carrying positions: front – inward facing front – outward facing back & on the hips Fully adjustable waist, shoulder, and chest straps ensure even weight distribution. Newly added 3-point safety buckles prevent accidental opening. Tested to ensure proper ergonomic positioning for you (even during nursing), Dads, and for baby — no matter how you wear it. Its tall and wide body with foldable headrest supports your growing baby in the proper positioning for each growth phase, and a wide padded waist belt offers extra lumbar support. TheHonestCompany.com", GMO = false, Price = 100.22, Quantity = 100, CorporationId = 12 },

                    new Product() { CategoryId = 3, ImageLink = "OrganicSwaddle.jpg", Name = "Organic Swaddle", Details = "Lovingly wrap your little ones in our soft, organic cotton muslin swaddles. Made with GOTS certified organic cotton and non-toxic, low-impact dyes, these organic swaddling blankets are gentle on baby’s skin and perfect for sleep time, cuddle time, nursing, travel, and play. We designed these exclusive collections to inspire every little one to imagine the endless possibilities of adventure and exploration. The Honest Company", GMO = false, Price = 100.22, Quantity = 100, CorporationId = 12 },

                    new Product() { CategoryId = 1, ImageLink = "Prenatal2.jpg", Name = "Prenatal Vitamins", Details = "Enriching Folate. Now with the highly bioavailable form of Folate, L-Methylfolate, to help with absorption.* Nutritionally Balanced. Complete multi-vitamin and mineral supplement containing nutrients like Folate and Iron, which support baby's healthy growth and development.* Nourishing for Mom. Balanced combination of vitamins and minerals to support mom's growing nutritional needs during pregnancy.* Ultra Gentle. Vitamin B6 and Ginger are included to help calm mom's tummy. The naturally derived sweet coating makes them easy to take and keep down!* Added Probiotics. 500 million beneficial (CFU) probiotics and plant sources of digestive enzymes to help support digestion, a healthy immune system, and overall intestinal health.* Powerful Antioxidants. Vitamin A (as Beta Carotene), Vitamin C and Vitamin E are included to provide powerful antioxidant protection by neutralizing free radicals in both mom and baby's growing bodies.* Doctor Reviewed & Formulated. We rely on our team of practicing doctors and health experts to ensure a balanced nutritional formulation. Purity Matters. Carefully sourced and blended to be ultra pure and HONESTLY FREE of commonly found binders, fillers, allergens, synthetic additives, pesticides, and contaminants.Our Prenatal Complete multi-vitamin blend has been thoughtfully formulated with highly bioavailable forms of nutrients (like L-Methylfolate, methylcobalamin, and beta carotene), and added probiotics, digestive enzymes, antioxidants, and superfoods to meet the growing needs of both mom and baby.* All in just one tablet per day! For more information about this product, check out TheHonestCompany.com", GMO = false, Price = 100.22, Quantity = 100, CorporationId = 12 },

                    new Product() { CategoryId = 3, ImageLink = "RadiationBlanket.jpg", Name = "Radiation Blanket", Details = "Peace of mind meets comfort with our organic cotton blanket designed to protect mom and baby from the risks of everyday radiation. Neutralizes and actively reduces incoming electromagnetic waves, canceling out the ambient radiation with 99.9% efficacy against cell phones, laptops, and handheld electronic devices. Our cozy blanket is made with lightweight, ultra soft 100% GOTS Certified Organic Cotton and lined with patented RadiaShield® Fabric — a lightweight, conductive textile with shielding properties (similar to ¼\" thick aluminum!), which has been independently tested and laboratory verified (FCC-certified and NVLAP-accredited) to effectively shield 99.9% of everyday radiation. There is nothing more important in this world than the health and safety of your child. While the risks and dangers of everyday radiation remain largely unknown, health experts recommend applying the 'precautionary principle' – especially during pregnancy and early childhood. We've been longtime advocates and fans of the work of Belly Armor, and couldn't wait to collaborate with them on a special project to bring their product to our Honest line.For more information about this product, check out TheHonestCompany.com", GMO = false, Price = 100.22, Quantity = 100, CorporationId = 12 },

                    new Product() { CategoryId = 3, ImageLink = "ShampooBodyWash.jpg", Name = "Shampoo & Body Wash", Details = "Natural and organic ingredients gently cleanse, moisturize, and nourish your baby and family's entire body from head to toe . Jojoba and quinoa proteins strengthen and fortify (with all 8 essential amino acids). Organic coconut oil moisturizes and protects. Chamomile, calendula, and aloe gently soothe and nourish. Fresh smelling sweet orange vanilla. Perfectly pH balanced to remove dirt without stripping natural oils, and protect tender skin and delicate hair. Gentle enough for babies with sensitive skin, eczema, or cradle cap. Safe for Mom's color-treated hair. No harsh chemicals (ever!) - honestly clean and extremely satisfying. Hypoallergenic • Tear-Free • Color-Safe • Vegan • Biodegradable • pH Balanced • Naturally Non-Toxic The Honest Company", GMO = false, Price = 100.22, Quantity = 100, CorporationId = 12 },

                    new Product() { CategoryId = 3, ImageLink = "SiliconePic.jpg", Name = "Silicone Bottle", Details = "Extra soft, squeezable bottle and anti-colic, medical-grade peristaltic nipple mimics natural breastfeeding to provide easy assimilation and transitions between breast and bottle feeding.", GMO = false, Price = 100.22, Quantity = 100, CorporationId = 12 },

                    new Product() { CategoryId = 3, ImageLink = "SprayCleanerRefills2.jpg", Name = "Spray Bottle Refills", Details = "Know what’s even better than recycling? Reusing. Now with our Honest Concentrate Refills, you can reuse the Honest Spray Bottles you have — over & over again. Plus, by opting for a Concentrate Refill instead of a full-size Spray Cleaner, you are saving more than just plastic*: Water consumption savings - 74% Fossil Fuel consumption savings - 77% Greenhouse gas emissions savings - 75% Mineral consumption savings - 75% Packaging consumption (by weight in grams) savings - 77% So to sum it up: same great cleaner (say goodbye, dirt!), save plastic, water, fossil fuels & GHGs — delightful eco-brilliance? dvanced plant-based concentrates tackle dirt, grease & grime anywhere, anytime – just add water! Available for all 5 of our super versatile & ultra effective natural spray & surface cleaners.For more information about this product, check out TheHonestCompany.com", GMO = false, Price = 100.22, Quantity = 100, CorporationId = 12 },

                    //end Honest Company

            //----------AlterEco Company----------------//

                     new Product() { CategoryId = 1, ImageLink = "Almond_Raw.jpg", Name = "Almond Raw", Details = "Carefully roasted Spanish almonds take their place among deep, malty Ecuadorian chocolate for a buttery-sweet, sophisticated crunch. Our expert Swiss chocolatiers add a touch of Madagascar vanilla bean to round out the short list of Fair Trade Organic ingredients, transforming this classic standby into a wholesome and heartfelt superfood indulgence. The deep intensity of Dark Almond reflects the rainforest from which it hails. Fortaleza sits on the edge of the Ecuadorian coast, where the world’s richest soil and the shade of the forest canopy create an ideal environment for native cacao.   - See more at: http://www.alterecofoods.com/product/dark-almond/#sthash.MrhGAnCZ.dpuf", GMO = false, Price = 100.22, Quantity = 100, CorporationId = 6 },

                 new Product() { CategoryId = 1, ImageLink = "Black_Truffle-300x278.jpg", Name = "Black Truffles", Details = "The sweet, rich deliciousness we all love is no longer just good–it can be really, really good for you. We set out to reinvent the most awe-inspiring, over-the-top, incredible chocolate experience ever: the truffle. Given that signature creamy center by mixing cacao with the superfood coconut oil, its the perfect compliment for antioxidant-rich dark chocolate. Our pure organic coconut oil comes from Kerala Fair Trade Alliance on India’s Malabar Coast. This farmer-owned coop practices “jaiva krishi”, a sustainable farming method mimicking virgin rainforest, where birds, squirrels and even wild elephants roam safely.  - See more at: http://www.alterecofoods.com/product/dark-black-truffles/#sthash.j3RBcq9D.dpuf", GMO = false, Price = 100.22, Quantity = 100, CorporationId = 6 },

                 new Product() { CategoryId = 1, ImageLink = "Jasmine_Raw.jpg", Name = "HomMali Jasmine Rice", Details = "Rice is so central to the diet in Thailand that the literal translation of “I’m hungry” is “I’m hungry for rice.” This crop has been cultivated in the country’s tropical terrain for centuries, in nearly limitless varieties. From the fragrant grains of Hom Mali Jasmine to the bold beauty of Khao Deng Ruby and the sweet subtlety of Purple Sticky Rice, we proudly preserve these native heirloom grains for a new generation to enjoy. - See more at: http://www.alterecofoods.com/product/hom-mali-jasmine-rice/#sthash.SVVwDW72.dpuf", GMO = false, Price = 100.22, Quantity = 100, CorporationId = 41 },


                 new Product() { CategoryId = 1, ImageLink = "Sugar_Raw.jpg", Name = "Mascobado Cane Sugar", Details = "In today’s culinary world of rare spices and specialty salts, Alter Eco Organic Mascobado Cane Sugar offers an exceptional kind of sweetness. This traditional unrefined sugar retains the essence of the Islang Asukal it came from, with rich flavors that range from delicate caramel and vanilla to malty molasses and marshmallow. And because its untouched by modern refining processes, each grain possesses all the nutrients of the Philippines’ raw native sugar cane. - See more at: http://www.alterecofoods.com/product/mascobado-cane-sugar/#sthash.sqswJBkU.dpuf", GMO = false, Price = 100.22, Quantity = 100, CorporationId = 6 },

                 new Product() { CategoryId = 1, ImageLink = "BlackQuinoa_Raw.jpg", Name = "Royal Black Quinoa", Details = "13,000 feet up on the arid, desolate Salar De Uyuni salt flat of Bolivia, traditional Quechua and Aymara farmers tend to fields of highly coveted “quinoa real,” or royal quinoa, an ancient variety grown only in this very spot. This pearl-shaped, nearly perfect nutrition source was so revered by the Incas that they called it “chisaya mama” or “mother grain.” The wild crunch of our Royal Black Quinoa pairs well with bright herbs and bold flavor.  - See more at: http://www.alterecofoods.com/product/royal-black-quinoa/#sthash.2qMwxmER.dpuf", GMO = false, Price = 100.22, Quantity = 100, CorporationId = 6 },

                 new Product() { CategoryId = 1, ImageLink = "PurpleRiceRaw_280x260.jpg", Name = "Thai Sticky Purple Rice", Details = "Rice is so central to the diet in Thailand that the literal translation of “I’m hungry” is “I’m hungry for rice.” This crop has been cultivated in the country’s tropical terrain for centuries, in nearly limitless varieties. From the fragrant grains of Hom Mali Jasmine to the bold beauty of Khao Deng Ruby and the sweet subtlety of Purple Sticky Rice, we proudly preserve these native heirloom grains for a new generation to enjoy - See more at: http://www.alterecofoods.com/product/thai-sticky-purple-rice/#sthash.sdJoAGfC.dpuf", GMO = false, Price = 100.22, Quantity = 100, CorporationId = 6 },

                 //-----END ALTERECO COMPANY-------------//

                 //-----START Andean Naturals COMPANY-------------//

                 new Product() { CategoryId = 1, ImageLink = "GoldenRoyal_Main.jpg", Name = "Golden Quinoa", Details = "Impressive dimensions, rich flavor and crunchy-yet-yielding texture make these seeds an unfailing attention-getter as a side dish. Not every main dish can stand the competition – let alone quinoa from beyond the briny borders of the Salar.", GMO = false, Price = 100.22, Quantity = 100, CorporationId = 7 },

                 new Product() { CategoryId = 1, ImageLink = "Flour_Main.jpg", Name = "Quinoa Flour", Details = "Higher in protein than any other flour, grain-free, gluten-free. Great news for bakers of flatbreads, pancakes, muffins, cookies and brownies and all who like to eat them. Our quinoa flour is stone-ground to ivory smoothness and can be ordered toasted for extra nutty flavor.", GMO = false, Price = 100.22, Quantity = 100, CorporationId = 7 },

                 new Product() { CategoryId = 1, ImageLink = "RedRoyal_Main.jpg", Name = "Red Royal Quinoa", Details = "Impressive dimensions, rich flavor and crunchy-yet-yielding texture make these seeds an unfailing attention-getter as a side dish. Not every main dish can stand the competition – let alone quinoa from beyond the briny borders of the Salar.", GMO = false, Price = 100.22, Quantity = 100, CorporationId = 7 },

                 new Product() { CategoryId = 1, ImageLink = "Flakes_Main.jpg", Name = "Quinoa Flakes", Details = "Kick out glutens, ramp up the protein and taste the goodness at bakery counters, breakfast tables and snack time. Golden or red, our flakes add the magic of the mother grain to hot cereals, energy bars, hearty granola mixes and the most satisfying of meatloaves.", GMO = false, Price = 100.22, Quantity = 100, CorporationId = 7 },

                 new Product() { CategoryId = 1, ImageLink = "Germ_Main.jpg", Name = "Toasted Quinoa Germ", Details = "When we separate the bran and germ from the rest of  the seed, out pops the power of  39% protein, high-fiber, 100% freedom from glutens. We germinate golden and red seeds then lightly toast them for crunchy flavor that'??s perfect for sprinkling on soups and salads, ideal for a host of  bakery applications.", GMO = false, Price = 100.22, Quantity = 100, CorporationId = 7 },

                  new Product() { CategoryId = 1, ImageLink = "Tricolor_Main.jpg", Name = "Tri-Color Quinoa", Details = "Custom blends of  Golden, Red and Black seeds stir excitement from palette to palate, a rainbow of flavor and nutrition configured precisely to order. Pure eye candy, true natural goodness, fair rewards for farmers.", GMO = false, Price = 100.22, Quantity = 100, CorporationId = 7 },

                  //----------END Andean Natural Company-----------//

                  //---------------START Atayne LLC---------------------//

                  new Product() { CategoryId = 17, ImageLink = "mt2010_4rs-run_medium_sky_front.jpg", Name = "Recycle-Run - Men's Running Shirt", Details = "Atayne's Long Sleeve REC T Elite with the Reduce, Reuse, Recycle, Run design is perfect for those who play hard, tread lightly, and would rather promote their values than just the logo of a multi-million dollar corporation. This performance top is made from a lightweight 100% recycled polyester micro mesh fabric that wicks moisture and dries quickly. The vivid, fully sublimated design allows athletes to perform at their best while spreading an important environmental message. ", GMO = false, Price = 100.22, Quantity = 100, CorporationId = 9 },

                  new Product() { CategoryId = 17, ImageLink = "MensStraightNarrowShirt.jpg", Name = "Men's Straight and Narrow Shirt", Details = "Atayne's Long Sleeve REC T Elite with the I Run Straight but Not Narrow design is perfect for those who play hard, tread lightly, and would rather promote their values than just the logo of a multi-million dollar corporation. This performance top is made from a lightweight 100% recycled polyester micro mesh fabric that wicks moisture and dries quickly. The vivid, fully sublimated design allows athletes to perform at their best while spreading an important human rights message. ", GMO = false, Price = 100.22, Quantity = 100, CorporationId = 9 },

                  new Product() { CategoryId = 1, ImageLink = "MensRunHardTreadLightlyShirt.jpg", Name = "Run Hard, Tread Lightly - Men's Running Shirt", Details = "Atayne's Long Sleeve REC T Elite with the Run Hard Tread Lightly design is perfect for those who play hard, tread lightly, and would rather promote their values than just the logo of a multi-million dollar corporation. This performance top is made from a lightweight 100% recycled polyester micro mesh fabric that wicks moisture and dries quickly. The vivid, fully sublimated design allows athletes to perform at their best while spreading an important environmental message.", GMO = false, Price = 100.22, Quantity = 100, CorporationId = 9 },

                  new Product() { CategoryId = 17, ImageLink = "WomensLongSleeveShirt.jpg", Name = "Women's Long Sleeve Shirt", Details = "Atayne's Long Sleeve REC T Elite with the I Run Straight but Not Narrow design is perfect for those who play hard, tread lightly, and would rather promote their values than just the logo of a multi-million dollar corporation. This performance top is made from a lightweight 100% recycled polyester micro mesh fabric that wicks moisture and dries quickly. The vivid, fully sublimated design allows athletes to perform at their best while spreading an important human rights message.", GMO = false, Price = 100.22, Quantity = 100, CorporationId = 9 },

                  new Product() { CategoryId = 17, ImageLink = "WomensShortSleeveShirt.jpg", Name = "Women's Short Sleeve Shirt", Details = "Atayne's B the Change REC Cycling Jersey is perfect for those who ride hard and tread lightly. This performance jersey is made from a lightweight 100% recycled polyester mesh fabric that wicks moisture and dries quickly. 5% of sales will be donated to B Lab's efforts to create a global movement of entrepreneurs using the power of business to solve social and environmental problems.", GMO = false, Price = 100.22, Quantity = 100, CorporationId = 9 },

                  new Product() { CategoryId = 17, ImageLink = "WomensStraightNarrowShirt.jpg", Name = "Women's Straight & Narrow Shirt", Details = "Atayne's Long Sleeve REC T Elite with the I Run Straight but Not Narrow design is perfect for those who play hard, tread lightly, and would rather promote their values than just the logo of a multi-million dollar corporation. This performance top is made from a lightweight 100% recycled polyester micro mesh fabric that wicks moisture and dries quickly. The vivid, fully sublimated design allows athletes to perform at their best while spreading an important human rights message. ", GMO = false, Price = 100.22, Quantity = 100, CorporationId = 9 },

                  //-------------END ATAYNE LLC--------------//

                  //---------------BEGIN CDI Company-----------//

                  new Product() { CategoryId = 17, ImageLink = "CameraSelfieHolder.jpg", Name = "Camera Selfie Holder", Details = "Durable metal shaft, lightweight, usable and easy to carry with. Fit most of compact cameras and mobile phones, connecting to the tripod mount of cameras or mobile phone. Considerate design of taking video. Non-slip handle for better using experience and wonderful touch feeling and providing convenience for the users while they are taking photos. You have 11 different colors to choose. It includes a selfie stick, a phone clip , a pouch and a gift box. The holder can extend to 41\".Free Shipping.S. 9 7/8\" L x 1 1/4\" Thick x 1 1/8\" H ", GMO = false, Price = 100.22, Quantity = 100, CorporationId = 11 },

                  new Product() { CategoryId = 17, ImageLink = "BevNapkin.jpg", Name = "Bev Napkin", Details = "Napkins are essential at events where refreshments are served, so take advantage of this great marketing opportunity! Our napkins are environmentally friendly, biodegradable, and made from renewable resources. Unlimited number of imprint colors available! This product may be Debossed, Embossed, Hot Stamped, Screen Printed, or purchased without imprint. Free PMS matching. Metallic and neon ink colors offered at no extra cost. Made and Printed in the USA. 5\" W x 5\" H", GMO = false, Price = 100.22, Quantity = 100, CorporationId = 11 },

                  new Product() { CategoryId = 18, ImageLink = "FoldableUmbrella.jpg", Name = "Foldable Umbrella", Details = "Unfold your next marketing campaign with this 170T polyester fabric folding umbrella! This promo product features a 40\" arc and folds into a compact 13\". Enhance the 4\" x 6\" imprint area with a silkscreened representation of your company's name or logo and create a fantastic giveaway. This solid color item is a perfect promotional choice for banks, insurance companies, healthcare facilities, golf clubs and many more!", GMO = false, Price = 100.22, Quantity = 100, CorporationId = 11 },

                  new Product() { CategoryId = 17, ImageLink = "MicroFiberCloth.jpg", Name = "Micro Fiber Cloth", Details = "The softest, thickest most luxurious microfiber cloth on the market (245 gsm). Clients will absolutely love them, will be used for years! Perfect for fragile screens and glasses. Easily removes fingerprints, moisture and smudges without scratching. Fabulous durable canvas to promote your brand and spread your message, with amazing high quality text and graphics. Comprised of 80% Polyester 20% Polyamide, beware of cheap 100% Polyester cloths that scratch screens!. 5\" L x 5\" W", GMO = false, Price = 100.22, Quantity = 100, CorporationId = 11 },

                   new Product() { CategoryId = 17, ImageLink = "SiliconeBracelets.jpg", Name = "Silicone Bracelets", Details = "Solid-color silicone wristband with debossed imprint. Environmentally friendly. Make more than a fashion statement as you proudly display your company name and logo or increase awareness for a special cause. PMS Color Match available at no additional cost. 8\" L x 1/2\" W", GMO = false, Price = 100.22, Quantity = 100, CorporationId = 11 },

                   new Product() { CategoryId = 18, ImageLink = "SportsWaterBottle.jpg", Name = "Sports Water Bottle", Details = "20 Oz. Aluminum water bottle, carabiner, gift box, BPA free. 8 1/2\" H x 2 7/8\" Diameter", GMO = false, Price = 100.22, Quantity = 100, CorporationId = 11 },

                   //----------END CDI Company---------------------------------//

                   //----------START Clean Ethics Company---------------------//

                   new Product() { CategoryId = 18, ImageLink = "10PACK-Bottle-Bright-Tablets.jpg", Name = "10 Pack Bottle Bright", Details = "Bottle Bright effervescent tablets provide the best solution for cleaning your drinking vessels and beverage containers. Whether it’s a water bottle, travel mug, hydration reservoir, or thermos, we offer the safest and most effective method to care for your hard to clean drinking containers. Our biodegradable and non-toxic formula bubbles away grime and breaks down to inert natural substances and is certified by the Natural Products Association. With every purchase you make, Clean Ethics gives an equal amount of Bottle Bright to people in developing nations who are in vital need of clean water containers. Buy Clean. Give Clean.", GMO = false, Price = 100.22, Quantity = 100, CorporationId = 12 },

                   new Product() { CategoryId = 18, ImageLink = "10PACK_0006_2-Tablets.jpg", Name = "10 Pack Bottle Bright - 2 Pack", Details = "Bottle Bright effervescent tablets provide the best solution for cleaning your drinking vessels and beverage containers. Whether it’s a water bottle, travel mug, hydration reservoir, or thermos we offer the safest and most effective method to care for your hard to clean drinking containers. Our biodegradable and non-toxic formula bubbles away grime and breaks down to inert natural substances and is certified by the Natural Products Association. With every purchase you make, Clean Ethics gives an equal amount of Bottle Bright to people in developing nations who are in vital need of clean water containers. Buy Clean. Give Clean", GMO = false, Price = 100.22, Quantity = 100, CorporationId = 12 }

                   //----------END Clean Ethics Company---------------------------------//

                );
            }



        }

    }
}
