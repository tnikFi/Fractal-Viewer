# Fractal Viewer

[![Actions](https://github.com/tnikFi/Fractal-Viewer/actions/workflows/main.yml/badge.svg)](https://github.com/tnikFi/Fractal-Viewer/actions/workflows/main.yml)

A simple fractal viewing program written in C# using the Unity game engine. Renders a fractal on the screen and allows the user to zoom and pan around the fractal.

## Planned changes

- [ ] Add a way to select the fractal to view from a dropdown menu
- [ ] Add a way to change the fractal iteration count during runtime
- [x] Render the fractal on the GPU instead of the CPU (CPU is too slow, the program runs at very low FPS)
- [ ] Fix the fractal scale turning negative when zooming in too fast
