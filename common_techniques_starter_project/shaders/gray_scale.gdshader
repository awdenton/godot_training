shader_type canvas_item;

void fragment() {
	vec4 orig_color = texture(TEXTURE, UV);
	float gray_scale = (orig_color.r + orig_color.g + orig_color.b) / 3.0;
	COLOR = vec4(gray_scale, gray_scale, gray_scale, orig_color.a);
}