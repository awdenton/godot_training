shader_type canvas_item;

uniform vec4 flash_color: source_color = vec4(1.0);
uniform float flash_pct: hint_range(0.0, 1.0, 0.05) = 0.0;

void fragment() {	
	vec4 orig_color = texture(TEXTURE, UV);
	vec4 final_color = mix(orig_color, flash_color, flash_pct);
	COLOR = vec4(final_color.rgb, orig_color.a);
}