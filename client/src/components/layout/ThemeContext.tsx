import { createContext, useContext, useMemo, useState, type ReactNode } from "react";
import { createTheme, ThemeProvider, type PaletteMode } from "@mui/material";

interface ThemeContextType {
  mode: PaletteMode;
  toggleMode: () => void;
}

const ColorModeContext = createContext<ThemeContextType>({
  mode: "light",
  toggleMode: () => {},
});

export function useColorMode() {
  return useContext(ColorModeContext);
}

export default function ThemeContextProvider({ children }: { children: ReactNode }) {
  const [mode, setMode] = useState<PaletteMode>("dark");

  const toggleMode = () =>
    setMode((prev) => (prev === "light" ? "dark" : "light"));

  const theme = useMemo(
    () =>
      createTheme({
        palette: {
          mode,
          ...(mode === "light"
            ? {
                background: { default: "#f5f5f5" },
              }
            : {
                background: { default: "#121212" },
              }),
        },
      }),
    [mode]
  );

  return (
    <ColorModeContext.Provider value={{ mode, toggleMode }}>
      <ThemeProvider theme={theme}>{children}</ThemeProvider>
    </ColorModeContext.Provider>
  );
}
