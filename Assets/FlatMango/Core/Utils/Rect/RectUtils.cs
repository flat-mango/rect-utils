/* FlatMango.Utils.Rect.RectUtils.cs
 * 
 * Flat Mango (Oleh Zahorodnii)
 * flat.mango@protonmail.com
 * 
 */

namespace FlatMango.Core.Utils.Rect
{
    using Mathf         = UnityEngine.Mathf;
    using Rect          = UnityEngine.Rect;
    using RectOffset    = UnityEngine.RectOffset;
    using Vector2       = UnityEngine.Vector2;


    public static class RectUtils
    {
        /// <summary>
        /// Scale <paramref name="rect"/>'s width by <paramref name="w"/> and height by <paramref name="h"/>.
        /// </summary>
        /// <param name="rect">Rect to scale.</param>
        /// <param name="w">Width scale.</param>
        /// <param name="h">Height scale.</param>
        public static void Scale(ref Rect rect, float w, float h)
        {
            rect.width  *= w;
            rect.height *= h;
        }

        /// <summary>
        /// Scale <paramref name="rect"/>'s size by <paramref name="scale"/>.
        /// </summary>
        /// <param name="rect">Rect to scale.</param>
        public static void Scale(ref Rect rect, Vector2 scale)
        {
            rect.size.Scale(scale);
        }

        /// <summary>
        /// Scale <paramref name="rect"/>'s width by <paramref name="w"/> and height by <paramref name="h"/>
        /// relative to (<paramref name="px"/>, <paramref name="py"/>) pivot point.
        /// </summary>
        /// <param name="rect">Rect to scale</param>
        /// <param name="w">Width scale.</param>
        /// <param name="h">Height scale.</param>
        /// <param name="px">x component of scaling pivot.</param>
        /// <param name="py">y component of scaling pivot.</param>
        public static void Scale(ref Rect rect, float w, float h, float px, float py)
        {
            float width  = rect.width * w;
            float height = rect.height * h;

            float x = rect.x + px * rect.width - px * rect.width * w;
            float y = rect.y + py * rect.height - py * rect.height * h;

            rect.Set(x, y, width, height);
        }

        /// <summary>
        /// Scale <paramref name="rect"/>'s size by <paramref name="scale"/>
        /// relative to (<paramref name="px"/>, <paramref name="py"/>) pivot point.
        /// </summary>
        /// <param name="rect">Rect to scale.</param>
        /// <param name="px">x component of scaling pivot.</param>
        /// <param name="py">y component of scaling pivot.</param>
        public static void Scale(ref Rect rect, Vector2 scale, float px, float py)
        {
            float width  = rect.width * scale.x;
            float height = rect.height * scale.y;

            float x = rect.x + px * rect.width - px * rect.width * scale.x;
            float y = rect.y + py * rect.height - py * rect.height * scale.y;

            rect.Set(x, y, width, height);
        }

        /// <summary>
        /// Scale <paramref name="rect"/>'s width by <paramref name="w"/> and height by <paramref name="h"/>
        /// relative to <paramref name="pivot"/> point.
        /// </summary>
        /// <param name="rect">Rect to scale.</param>
        /// <param name="w">Width scale.</param>
        /// <param name="h">Height scale.</param>
        public static void Scale(ref Rect rect, float w, float h, Vector2 pivot)
        {
            float width  = rect.width * w;
            float height = rect.height * h;

            float x = rect.x + pivot.x * rect.width - pivot.x * rect.width * w;
            float y = rect.y + pivot.y * rect.height - pivot.y * rect.height * h;

            rect.Set(x, y, width, height);
        }

        /// <summary>
        /// Scale <paramref name="rect"/>'s size by <paramref name="scale"/>
        /// relative to <paramref name="pivot"/> point.
        /// </summary>
        /// <param name="rect">Rect to scale.</param>
        public static void Scale(ref Rect rect, Vector2 scale, Vector2 pivot)
        {
            float width  = rect.width * scale.x;
            float height = rect.height * scale.y;

            float x = rect.x + pivot.x * rect.width - pivot.x * rect.width * scale.x;
            float y = rect.y + pivot.y * rect.height - pivot.y * rect.height * scale.y;

            rect.Set(x, y, width, height);
        }

        /// <summary>
        /// Apply offset to the <paramref name="rect"/>.
        /// </summary>
        public static void Offset(ref Rect rect, float right, float left, float top, float bottom)
        {
            rect.x += left;
            rect.y += top;
            rect.width  = rect.width - right - left;
            rect.height = rect.height - top - bottom;
        }

        /// <summary>
        /// Apply <paramref name="offset"/> to the <paramref name="rect"/>.
        /// </summary>
        public static void Offset(ref Rect rect, RectOffset offset)
        {
            rect.x += offset.left;
            rect.y += offset.top;
            rect.width  -= offset.horizontal;
            rect.height -= offset.vertical;
        }

        /// <summary>
        /// Apply offset of <paramref name="value"/> for all sides
        /// of the <paramref name="rect"/>.
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="value"></param>
        public static void Offset(ref Rect rect, float value)
        {
            rect.x += value;
            rect.y += value;
            rect.width  -= value * 2;
            rect.height -= value * 2;
        }

        /// <summary>
        /// Align right side of <paramref name="rect"/> to <paramref name="x"/>.
        /// </summary>
        public static void AlignRight(ref Rect rect, float x)
        {
            rect.x = x - rect.width;
        }

        /// <summary>
        /// Align right side of <paramref name="rect"/>
        /// to the right of <paramref name="target"/>.
        /// </summary>
        public static void AlignRight(ref Rect rect, Rect target)
        {
            rect.x = target.x + target.width - rect.width;
        }

        /// <summary>
        /// Align left side of <paramref name="rect"/> to <paramref name="x"/>.
        /// </summary>
        public static void AlignLeft(ref Rect rect, float x)
        {
            rect.x = x;
        }

        /// <summary>
        /// Align left side of <paramref name="rect"/>
        /// to the left side of <paramref name="target"/>.
        /// </summary>
        public static void AlignLeft(ref Rect rect, Rect target)
        {
            rect.x = target.x;
        }

        /// <summary>
        /// Align top side of <paramref name="rect"/> to <paramref name="y"/>.
        /// </summary>
        public static void AlignTop(ref Rect rect, float y)
        {
            rect.y = y;
        }

        /// <summary>
        /// Align top side of <paramref name="rect"/>
        /// to the top side of <paramref name="target"/>.
        /// </summary>
        public static void AlignTop(ref Rect rect, Rect target)
        {
            rect.y = target.y;
        }

        /// <summary>
        /// Align bottom side of <paramref name="rect"/> to <paramref name="y"/>.
        /// </summary>
        public static void AlignBottom(ref Rect rect, float y)
        {
            rect.y = y - rect.width;
        }

        /// <summary>
        /// Align bottom side of <paramref name="rect"/>.
        /// to the bottom side of <paramref name="target"/>.
        /// </summary>
        public static void AlignBottom(ref Rect rect, Rect target)
        {
            rect.y = target.y + target.height - rect.height;
        }

        /// <summary>
        /// Align <paramref name="rect"/>'s center to <paramref name="positon"/>.
        /// </summary>
        public static void AlignCenter(ref Rect rect, Vector2 positon)
        {
            rect.center = positon;
        }

        /// <summary>
        /// Align <paramref name="rect"/>'s center to the center of <paramref name="target"/>.
        /// </summary>
        public static void AlignCenter(ref Rect rect, Rect target)
        {
            rect.center = target.center;
        }

        /// <summary>
        /// Align <paramref name="rect"/> to (<paramref name="x"/>, <paramref name="y"/>)
        /// using (<paramref name="px"/>, <paramref name="py"/>) as pivot point.
        /// </summary>
        /// <param name="px">x component of the pivot.</param>
        /// <param name="py">y component of the pivot.</param>
        /// <param name="x">x component of position to align to.</param>
        /// <param name="y">y component of position to alight to.</param>
        public static void Align(ref Rect rect, float px, float py, float x, float y)
        {
            rect.x = x - rect.width * px;
            rect.y = y - rect.height * py;
        }

        /// <summary>
        /// Align <paramref name="rect"/> to (<paramref name="x"/>, <paramref name="y"/>)
        /// using <paramref name="pivot"/> as the pivot point.
        /// </summary>
        /// <param name="x">x component of position to align to.</param>
        /// <param name="y">y component of position to alight to.</param>
        public static void Align(ref Rect rect, Vector2 pivot, float x, float y)
        {
            rect.x = x - rect.width * pivot.x;
            rect.y = y - rect.height * pivot.y;
        }

        /// <summary>
        /// Align <paramref name="rect"/> to <paramref name="position"/>
        /// using (<paramref name="px"/>, <paramref name="py"/>) as pivot point.
        /// </summary>
        /// <param name="px">x component of the pivot.</param>
        /// <param name="py">y component of the pivot.</param>
        public static void Align(ref Rect rect, float px, float py, Vector2 position)
        {
            rect.x = position.x - rect.width * px;
            rect.y = position.y - rect.height * py;
        }

        /// <summary>
        /// Align <paramref name="rect"/> to <paramref name="position"/>
        /// using <paramref name="pivot"/> as the pivot point.
        /// </summary>
        /// <param name="pivot">Anchor point of <paramref name="rect"/>.</param>
        public static void Align(ref Rect rect, Vector2 pivot, Vector2 position)
        {
            rect.x = position.x - rect.width * pivot.x;
            rect.y = position.y - rect.height * pivot.y;
        }

        /// <summary>
        /// Clamp <paramref name="rect"/> by <paramref name="bounds"/>
        /// so the resulting rect will be their overlapping area.
        /// </summary>
        public static void Clamp(ref Rect rect, Rect bounds)
        {
            rect.xMin = Mathf.Clamp(rect.xMin, bounds.xMin, bounds.xMax);
            rect.xMax = Mathf.Clamp(rect.xMax, bounds.xMin, bounds.xMax);

            rect.yMin = Mathf.Clamp(rect.yMin, bounds.yMin, bounds.yMax);
            rect.yMax = Mathf.Clamp(rect.yMax, bounds.yMin, bounds.yMax);
        }
    }
}