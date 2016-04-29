using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFMLproject.Encounter_ENV;
using SFMLproject.StaticFields;
using SFMLproject.Object;
using SFML.System;

namespace SFMLproject.Menu
{
    class MenuPrincipal
    {
        public Color background = new Color(135, 206, 250);
        public Color backHigh = new Color(0, 0, 0);
        public Color border = new Color(255, 215, 0);
        public Color bordHigh = new Color(255, 140, 0);
        public float borderSize;
        public Color text = new Color(0, 0, 0);
        public Color textHigh = new Color(205, 38, 38);
        public TextProperties tProp = new TextProperties();
        public Font font; 
        public List<ButtonClickMenu> entries = new List<ButtonClickMenu>();
        public int padding;
        public Vector2f dimensions;
        public bool visible = false;
        public RectangleShape shape;
        public View view;
        public int position;

        public MenuPrincipal(Vector2f dim, int pad, float bordS, View v)
        {
            dimensions = dim;
            padding = pad;
            borderSize = bordS;
            view = v;
            position = 0;

            //Background
            shape = new RectangleShape(dimensions);
            shape.FillColor = background;
            shape.OutlineThickness = borderSize;
            shape.OutlineColor = border;
        }

        public void addButton(string t, Encounter_ENV.Command c)
        {
            Text texte = new Text(t, tProp.font, (uint)(dimensions.Y - borderSize - padding));
            texte.Color = text;
            ButtonClickMenu button = new ButtonClickMenu(c, new RectangleShape(shape), texte);
            entries.Add(button);
        }

        public void setPosition(int p)
        {
            if (p >= entries.Count) position = 0;
            else if (p < 0) position = entries.Count - 1;
            else position = p;
        }

        public void addButton(ButtonClickMenu b)
        {
            entries.Add(b);
        }

        public Vector2f getSize()
        {
            return new Vector2f(dimensions.X, dimensions.Y* entries.Count);
        }

        public int getEntry(Vector2f mouse)
        {
            if (entries.Count == 0 || !visible) return -1;
            for (int i = 0; i<entries.Count; i++)
            {
                Vector2f pt = mouse;
                pt += entries[i].shape.Origin;
                pt -= entries[i].shape.Position;

                if (pt.X< 0 || pt.X> entries[i].shape.Scale.X* dimensions.X) continue;
                if (pt.Y< 0 || pt.Y> entries[i].shape.Scale.Y* dimensions.Y) continue;
                return i;
            }
            return -1;
        }

        public void setDimensions(Vector2f dim)
        {
            dimensions = dim;
            for (int i = 0; i<entries.Count; i++)
            {
                entries[i].shape.Size = dimensions;
                entries[i].text.CharacterSize = (uint)(dimensions.Y/2 - borderSize - padding);
            }
            return;
        }

        internal void addElement(AttackList attackList)
        {
        }

        public void addElement(MenuTextElement attackList)
        {
        }

        public void draw(RenderWindow window)
        {
            if (!visible) return;
            window.SetView(window.DefaultView);
            for (int i = 0; i<entries.Count; i++)
            {
                window.Draw(entries[i].shape);
                window.Draw(entries[i].text);
            }
            window.SetView(Executer.map.getMapview());
            return;
        }

        public void show()
        {
            visible = true;

            for (int i = 0; i<entries.Count; i++)
            {
                Vector2f origin = shape.Origin;
                //origin += offset;
                entries[i].shape.Origin = origin;
                entries[i].text.Origin = origin;
                entries[i].shape.Position = new Vector2f(0, (i)* dimensions.Y);
                entries[i].text.Position = new Vector2f(0, (i) * dimensions.Y);
                origin.Y += dimensions.Y;
            }
            return;
        }

        public void hide()
        {
            visible = false;
            return;
        }

        public void highlight(int e)
        {
            for (int i = 0; i<entries.Count; i++)
            {
                if (i == e)
                {
                    entries[i].shape.FillColor = backHigh;
                    entries[i].shape.OutlineColor = bordHigh;
                    entries[i].text.Color = textHigh;
                }
                else
                {
                    entries[i].shape.FillColor = background;
                    entries[i].shape.OutlineColor = border;
                    entries[i].text.Color = text;
                }
            }
            return;
        }

        public void activate(Vector2f mouse)
        {
            int entry = getEntry(mouse);
            highlight(entry);
            activate(entry);
        }

        public void activate(int b)
        {
            if (b == -1) return;
            highlight(b);
            draw(Executer.window);
            Executer.window.Display();
            entries[b].execute();
            highlight(-1);
            return;
        }
    }
}
