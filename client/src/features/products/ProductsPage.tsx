// import { useProducts, useCreateProduct } from "../../hooks/useProducts";


// export default function ProductsPage() {
//   const { data: products, isLoading } = useProducts();
//   const { mutate: createProduct } = useCreateProduct();

//   if (isLoading) return <p>Loading...</p>;

//   console.log(`Products data = ${products}`);

//   return (
//     <div className="p-6">
//       <h1 className="text-2xl font-bold mb-4">Products</h1>
//       <button
//         onClick={() => (console.log("Button does not work yet"))}
//         // createProduct({ 
//         //   id: '',
//         //   name: "New Product", 
//         //   price: 10,
//         //   isActive: true
//         // })}
//         className="bg-blue-600 text-white px-4 py-2 rounded"
//       >
//         Add Product
//       </button>
//       <ul className="mt-4 space-y-2">
//         {products?.map((p) => (
//           <li key={p.id} className="border p-2 rounded">
//             {p.name} — ${p.price}
//           </li>
//         ))}
//       </ul>
//     </div>
//   );
// }

import { useState } from "react";
import { Box, Drawer, Typography, Divider } from "@mui/material";
import { DataGrid, type GridColDef } from "@mui/x-data-grid";
import { useProducts, useCreateProduct } from "../../hooks/useProducts";
import type { Product } from "../products/productTypes";

export default function ProductsPage() {
  const { data: products, isLoading, isError } = useProducts();
  const { mutate: createProduct } = useCreateProduct();

  const [selected, setSelected] = useState<Product | null>(null);

  // Define the columns for the DataGrid
  const columns: GridColDef<Product>[] = [
    { field: "name", headerName: "Name", flex: 1, minWidth: 150 },
    { field: "description", headerName: "Description", flex: 2, minWidth: 200 },
    { field: "sku", headerName: "SKU", width: 120 },
    {
      field: "price",
      headerName: "Price",
      width: 120/*,
      valueFormatter: (params) => `$${params.value?.toFixed(2)}`,*/
    },
    {
      field: "isActive",
      headerName: "Active",
      width: 100,
      renderCell: (params) => (params.value ? "✅" : "❌"),
    },
  ];

  if (isLoading) return <Typography>Loading products...</Typography>;
  if (isError) return <Typography color="error">Failed to load products.</Typography>;

  return (
    <Box display="flex" height="100%" p={3}>
      {/* DataGrid Table */}
      <Box flex={1}>
        <Typography variant="h5" mb={2}>
          Products
        </Typography>

        <Box height={600} width="100%">
          <DataGrid
            rows={products ?? []}
            columns={columns}
            getRowId={(row) => row.id}
            onRowClick={(params) => setSelected(params.row)}
            disableRowSelectionOnClick
            pageSizeOptions={[10, 25, 50]}
            initialState={{
              pagination: { paginationModel: { pageSize: 10, page: 0 } },
            }}
          />
        </Box>
      </Box>

      {/* Detail Drawer */}
      <Drawer
        variant="persistent"
        anchor="right"
        open={!!selected}
        sx={{
          width: 400,
          flexShrink: 0,
          "& .MuiDrawer-paper": {
            width: 400,
            p: 3,
            boxSizing: "border-box",
          },
        }}
      >
        {selected && (
          <Box>
            <Typography variant="h6" gutterBottom>
              {selected.name}
            </Typography>
            <Divider sx={{ mb: 2 }} />
            <Typography variant="body1" gutterBottom>
              <strong>Description:</strong> {selected.description || "—"}
            </Typography>
            <Typography variant="body1" gutterBottom>
              <strong>SKU:</strong> {selected.sku || "—"}
            </Typography>
            <Typography variant="body1" gutterBottom>
              <strong>Price:</strong> ${selected.price.toFixed(2)}
            </Typography>
            <Typography variant="body1" gutterBottom>
              <strong>Status:</strong> {selected.isActive ? "Active" : "Inactive"}
            </Typography>

            <Box mt={3}>
              <Typography
                color="primary"
                sx={{ cursor: "pointer" }}
                onClick={() => setSelected(null)}
              >
                Close
              </Typography>
            </Box>
          </Box>
        )}
      </Drawer>
    </Box>
  );
}
