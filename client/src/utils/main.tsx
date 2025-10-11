import React from "react";
import ReactDOM from "react-dom/client";
import App from "./App";
import { QueryClient, QueryClientProvider } from "@tanstack/react-query";
import "./index.css";
import { CssBaseline } from "@mui/material";
import ThemeContextProvider from "../components/layout/ThemeContext";

const queryClient = new QueryClient();

// const theme = createTheme({
//   palette: {
//     mode: "light", // or "dark"
//   },
// });

ReactDOM.createRoot(document.getElementById("root")!).render(
  <React.StrictMode>
      <QueryClientProvider client={queryClient}>
        <ThemeContextProvider>
          <CssBaseline />
          <App />
        </ThemeContextProvider>
      </QueryClientProvider>
  </React.StrictMode>
);
